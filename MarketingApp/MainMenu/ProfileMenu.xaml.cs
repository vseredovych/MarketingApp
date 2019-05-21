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
using DAL.Core;
using System.Data.Common;
using System.Data;

namespace MarketingApp
{
    /// <summary>
    /// Логика взаимодействия для People.xaml
    /// </summary>
    public partial class ProfileMenu : UserControl
    {
        public UsersCollections Users;// = new ProductRepository();
        public DbHelper dbHelper;
        public User user;

        public ProfileMenu(User user)
        {
            InitializeComponent();
            FillUserProfileMenu(user);
            //Users = new UsersCollections();
            //ItemSourceMUsers.ItemsSource = Users.GetAll();

            //for (int i = 6; i < 100; i++)
            //{
            //    Products.Add(new Product
            //    {
            //        Id = i,
            //        Name = "Name" + i,
            //        CreatedAt = Convert.ToDateTime("2019-10-10"),
            //        MerchantId = i,
            //        Status = "Present"
            //    }
            //    );
            //}
        }

        private void FillUserProfileMenu(User user)
        {
            Id.Text = Convert.ToString(user.Id);
            FirstName.Text = Convert.ToString(user.FirstName);
            Mail.Text = Convert.ToString(user.Mail);
            Password.Text = Convert.ToString(user.Password);
            AccessLvl.Text = Convert.ToString(user.AccessLvl);

        }
        private void Gimme_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
