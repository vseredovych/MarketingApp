using DAL.Collections;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DAL.Core;
using System.Data;

namespace MarketingApp
{
    /// <summary>
    /// Логика взаимодействия для People.xaml
    /// </summary>
    public partial class RootMenu : UserControl
    {
        private DataTable data_table;
        private DbDataAdapter data_adapter;
        DbHelper DbHelper;
        public RootMenu()
        {
            DbHelper = new DbHelper();
            InitializeComponent();
            setupDataGridSettings();
            fillComboBox(ref combobox_choose_table);
        }
        private void setupDataGridSettings()
        {
            grid_tabels.CanUserAddRows = false;
            grid_tabels.IsReadOnly = true;
            grid_datatable_control.IsEnabled = false;
        }
        private void disableTableActions()
        {
            combobox_choose_table.IsEnabled = false;
            grid_datatable_control.IsEnabled = false;
        }
        private void enableTableActions()
        {
            combobox_choose_table.IsEnabled = true;
            grid_datatable_control.IsEnabled = true;
        }
        private void fillComboBox(ref ComboBox combobox_choose_table)
        {
            string querry = "show tables;";
            var reader = DbHelper.GetDataReader(querry);

            while (reader.Read())
            {
                combobox_choose_table.Items.Add(reader.GetString(0));
            }
            reader.Close();

        }
        private void fillDataGrid(DataGrid data_grid, string querry)
        {
            DbConnection connection = DbHelper.CreateConnection();
            DbCommand command = connection.CreateCommand();
            data_adapter = DbHelper.CreateDataAdapter(connection);
            command.CommandText = querry;
            data_adapter.SelectCommand = command;
            data_table = new DataTable();

            data_adapter.Fill(data_table);
            data_grid.ItemsSource = data_table.DefaultView;
            data_table.AcceptChanges();

            grid_datatable_control.IsEnabled = true;
        }
        private void updateDataTable()
        {
            data_table.Clear();
            data_adapter.Fill(data_table);
        }
        private void createDataGrid(DataGrid data_grid)
        {
            grid_tabels.Visibility = Visibility.Visible;
            grid_datatable_control.Visibility = Visibility.Visible;
            data_grid_change.Visibility = Visibility.Hidden;
            data_grid.ItemsSource = data_table.DefaultView;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillGridTableWithSelectedTable();
        }
        private void fillGridTableWithSelectedTable()
        {
            fillDataGrid(grid_tabels, "SELECT * FROM " + combobox_choose_table.SelectedItem + ";");
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = new TextBox();
            textBox.Text = "asd";
        }

        private void button_create_new_Click(object sender, RoutedEventArgs e)
        {
            disableTableActions();
            grid_ok_cancel.Visibility = Visibility.Visible;
            grid_tabels.IsReadOnly = false;
            grid_tabels.CanUserAddRows = true;
        }

        private void button_edit_Click(object sender, RoutedEventArgs e)
        {
            disableTableActions();
            grid_ok_cancel.Visibility = Visibility.Visible;
            grid_tabels.IsReadOnly = false;
            //data_table.AcceptChanges();
        }
        private void Button_accept_changes_Click(object sender, RoutedEventArgs e)
        {
            grid_tabels.IsReadOnly = true;
            grid_tabels.CanUserAddRows = false;
            grid_ok_cancel.Visibility = Visibility.Hidden;


            DbConnection connection = DbHelper.CreateConnection();
            DbCommandBuilder builder = DbHelper.CreateDbCommandBuilder(connection);
            DbCommand command = connection.CreateCommand();
            try
            {
                builder.DataAdapter = data_adapter;
                data_adapter.Update(data_table);
                data_table.Clear();
                data_adapter.Fill(data_table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            enableTableActions();
            updateDataTable();
        }

        private void Button_cancel_changes_Click(object sender, RoutedEventArgs e)
        {
            grid_tabels.IsReadOnly = true;
            grid_tabels.CanUserAddRows = false;
            grid_ok_cancel.Visibility = Visibility.Hidden;
            data_table.RejectChanges();
            fillGridTableWithSelectedTable();
            enableTableActions();
            updateDataTable();
        }

        private void Button_delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grid_tabels.SelectedIndex == -1)
                {
                    throw new System.ArgumentException("You don't select any item!");
                }
                DbHelper.CommandExecuteNonQuery("DELETE FROM " + combobox_choose_table.SelectedItem + " WHERE ID = " +
                    data_table.Rows[grid_tabels.SelectedIndex].ItemArray[0].ToString() + ";");
                updateDataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
