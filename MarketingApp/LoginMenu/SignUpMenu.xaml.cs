using System;
using System.Windows;
using System.Windows.Input;
using MarketingApp;
using DAL.Entities;
using DAL.Core;
using System.Data;
using DAL.Operations;

namespace MarketingApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class SignUpMenu : Window
    {
        User User;
        public SignUpMenu()
        {
            InitializeComponent();
        }
        private bool CreateNewUser()
        {
            if (email.Text != "" && password.Password != "" && firstname.Text != "")
            {
                User = new User();
                User.FirstName = firstname.Text;
                User.Password = password.Password;
                User.Gmail = email.Text;
                User.Id = 1;
                User.AccessLvl = 0;
                if (CreateNewUserInDatabase())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Invalid login or password!");
                return false;
            }
        }
        private bool CreateNewUserInDatabase()
        {
            UsersOperations usersOperations = new UsersOperations();
            if (usersOperations.InsertUserWithTransaction(User))
            {
                return true;
            }
            else
            {
                return false;
            }

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



        private void Login_Click_1(object sender, RoutedEventArgs e)
        {
            if (CreateNewUser())
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
                        MainMenu mainMenu = new MainMenu(4294967301);
                        this.Close();
                        mainMenu.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid login or password!");
                    }
                }
            }
        }
    }
}