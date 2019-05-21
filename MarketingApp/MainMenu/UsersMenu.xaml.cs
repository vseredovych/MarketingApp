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
        public MerchantsCollections Merchants;// = new ProductRepository();

        public UsersMenu()
        {
            InitializeComponent();
            Merchants = new MerchantsCollections();
            ItemSourceMUsers.ItemsSource = Merchants.GetAll();

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
    }
}
