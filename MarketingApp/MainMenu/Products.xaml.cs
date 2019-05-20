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

namespace MarketingApp
{
    /// <summary>
    /// Логика взаимодействия для People.xaml
    /// </summary>
    public partial class ProductsMenu : UserControl
    {
        public ProductsCollections Products;// = new ProductRepository();

        public ProductsMenu()
        {

            InitializeComponent();
            Products = new ProductsCollections();
            ItemSourceProducts.ItemsSource = Products.GetAll();
        }

    }
}
