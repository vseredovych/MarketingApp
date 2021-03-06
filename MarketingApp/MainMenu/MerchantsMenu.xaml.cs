﻿using DAL.Collections;
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
    public partial class MerchantsMenu : UserControl
    {
        public MerchantsCollections Merchants;

        public MerchantsMenu()
        {


            InitializeComponent();
            Merchants = new MerchantsCollections();
            ItemSourceMerchants.ItemsSource = Merchants.GetAll();
            //for (int i = 1; i < 100; i++)
            //{
            //    Merchants.Add(new User
            //    {
            //        Id = i,
            //        Dob = Convert.ToDateTime("2019-10-10"),
            //        FirstName = "Name" + 1,
            //        LastName = "LastName" + 1,
            //        CurrentCity = "Lviv",
            //    }
            // );
            //}
        }

        private void Gimme_Click(object sender, RoutedEventArgs e)
        {
            try {
                ItemSourceMerchants.ItemsSource = Merchants.GetInRange(Convert.ToInt32(MoreThen.Text), Convert.ToInt32(LessThen.Text));
            }
            catch
            {
                MessageBox.Show("Invalid data!");
            }
        }

        private void GetMoreThanAverageSalary_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ItemSourceMerchants.ItemsSource = Merchants.GetMoreThanAverage();
            }
            catch
            {
                MessageBox.Show("Invalid data!");
            }
        }
        private void GetAll_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                ItemSourceMerchants.ItemsSource = Merchants.GetAll();
            }
            catch
            {
                MessageBox.Show("Invalid data!");
            }
        }
    }
}
