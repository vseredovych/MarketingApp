using DAL.Collections;
using System;
using System.Collections.Generic;
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
using DAL.Entities;

namespace MarketingApp
{
    /// <summary>
    /// Логика взаимодействия для People.xaml
    /// </summary>
    public partial class UsersMenu : UserControl
    {
        public UsersCollections Users;

        public UsersMenu()
        {


            InitializeComponent();
            Users = new UsersCollections();
            ItemSourceUsers.ItemsSource = Users.GetAll();
            //for (int i = 1; i < 100; i++)
            //{
            //    Users.Add(new User
            //    {
            //        Id = i,
            //        Dob = Convert.ToDateTime("2019-10-10"),
            //        FirstName = "Name" + 1,
            //        LastName = "LastName" + 1,
            //        CurrentSity = "Lviv",
            //    }
            // );
            //}
        }

        private void Delete_User_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
