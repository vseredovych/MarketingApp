using System;
using System.Windows;
using System.Windows.Input;
using MarketingApp;

namespace MarketingApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //MainMenu mainMenu = new MainMenu(4294967301);
            //this.Close();
            //mainMenu.ShowDialog();
        }



        private void Login_Click(object sender, RoutedEventArgs e)
        {
            long id = -1;
            if (password.Password == "" || email.Text == "")
            {
                MessageBox.Show("No email or password entered!");
            }
            else
            {
                id = Authentication.userAuthentication(email.Text, password.Password);
                if (id > 0)
                {
                    MainMenu mainMenu = new MainMenu(id);
                    this.Close();
                    mainMenu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid login or password!");
                }
            }

        }
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Sign_Up_Click(object sender, RoutedEventArgs e)
        {
            SignUpMenu signUpMenu = new SignUpMenu();
            this.Close();
            signUpMenu.ShowDialog();
        }
    }
}