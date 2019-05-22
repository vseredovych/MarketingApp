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
        private DataTable DataTable;
        private DbDataAdapter DataAdapter;
        DbHelper DbHelper;
        public RootMenu()
        {
            DbHelper = new DbHelper();
            InitializeComponent();
            SetupDataGridSettings();
            FillComboBox(ref combobox_choose_table);
        }
        private void SetupDataGridSettings()
        {
            grid_tabels.CanUserAddRows = false;
            grid_tabels.IsReadOnly = true;
            grid_datatable_control.IsEnabled = false;
        }
        private void DisableTableActions()
        {
            combobox_choose_table.IsEnabled = false;
            grid_datatable_control.IsEnabled = false;
        }
        private void EnableTableActions()
        {
            combobox_choose_table.IsEnabled = true;
            grid_datatable_control.IsEnabled = true;
        }
        private void FillComboBox(ref ComboBox combobox_choose_table)
        {
            string querry = "show tables;";
            var reader = DbHelper.GetDataReader(querry);

            while (reader.Read())
            {
                combobox_choose_table.Items.Add(reader.GetString(0));
            }
            reader.Close();

        }
        private void FillDataGrid(DataGrid data_grid, string querry)
        {
            DbConnection connection = DbHelper.CreateConnection();
            DbCommand command = connection.CreateCommand();
            DataAdapter = DbHelper.CreateDataAdapter(connection);
            command.CommandText = querry;
            DataAdapter.SelectCommand = command;
            DataTable = new DataTable();

            DataAdapter.Fill(DataTable);
            data_grid.ItemsSource = DataTable.DefaultView;
            DataTable.AcceptChanges();

            grid_datatable_control.IsEnabled = true;
        }
        private void UpdateDataTable()
        {
            DataTable.Clear();
            DataAdapter.Fill(DataTable);
        }
        private void CreateDataGrid(DataGrid data_grid)
        {
            grid_tabels.Visibility = Visibility.Visible;
            grid_datatable_control.Visibility = Visibility.Visible;
            data_grid_change.Visibility = Visibility.Hidden;
            data_grid.ItemsSource = DataTable.DefaultView;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillGridTableWithSelectedTable();
        }
        private void FillGridTableWithSelectedTable()
        {
            FillDataGrid(grid_tabels, "SELECT * FROM " + combobox_choose_table.SelectedItem + ";");
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = new TextBox();
            textBox.Text = "asd";
        }

        private void Button_create_new_Click(object sender, RoutedEventArgs e)
        {
            DisableTableActions();
            grid_ok_cancel.Visibility = Visibility.Visible;
            grid_tabels.IsReadOnly = false;
            grid_tabels.CanUserAddRows = true;
        }

        private void Button_edit_Click(object sender, RoutedEventArgs e)
        {
            DisableTableActions();
            grid_ok_cancel.Visibility = Visibility.Visible;
            grid_tabels.IsReadOnly = false;
            //DataTable.AcceptChanges();
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
                builder.DataAdapter = DataAdapter;
                DataAdapter.Update(DataTable);
                DataTable.Clear();
                DataAdapter.Fill(DataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            EnableTableActions();
            UpdateDataTable();
        }

        private void Button_cancel_changes_Click(object sender, RoutedEventArgs e)
        {
            grid_tabels.IsReadOnly = true;
            grid_tabels.CanUserAddRows = false;
            grid_ok_cancel.Visibility = Visibility.Hidden;
            DataTable.RejectChanges();
            FillGridTableWithSelectedTable();
            EnableTableActions();
            UpdateDataTable();
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
                    DataTable.Rows[grid_tabels.SelectedIndex].ItemArray[0].ToString() + ";");
                UpdateDataTable();
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
