using System;
using System.Windows;
using System.Windows.Input;
using DAL.Authentication;

namespace MarketingApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //MainMenu mainMenu = new MainMenu();
            //this.Close();
            //mainMenu.ShowDialog();
            InitializeComponent();
            //this.Show();
        }



        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (Authentication.userAuthentication(email.Text, password.Password))
            {
                MainMenu mainMenu = new MainMenu();
                this.Close();
                mainMenu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid login or password!");
            }


        }
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}