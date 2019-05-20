using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Collections.ObjectModel;
using DAL.Collections;
using DAL.Entities;

namespace MarketingApp
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public ProductsCollections Products;// = new ProductRepository();
        public UsersCollections Users;// = new UserRepository();

        ProductsMenu productsMenu;
        StaffMenu staffMenu;

        public MainMenu()
        {
            //productRepository.FillRepositoryWithData();
            //userRepository.FillRepositoryWithData();
            //ItemS = productRepository();
            productsMenu = new ProductsMenu();
            staffMenu = new StaffMenu();
            Products = new ProductsCollections();
            Users = new UsersCollections();

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
            //);
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
            //    );
            //}
            productsMenu.ItemSourceProducts.ItemsSource = Products.GetAll();
            staffMenu.ItemSourceUsers.ItemsSource = Users.GetAll();

            InitializeComponent();
           
        }



        public void DragWindow(object sender, MouseButtonEventArgs args)
        {
            DragMove();
           
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ButtonPupUpLogOut_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;

        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            //userRepository.FillRepositoryWithData();
            switch (index)
            {
                case 0:
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(staffMenu);
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(productsMenu);
                    break;
                //case 2:
                //    GridPrincipal.Children.Clear();
                //    productRepository.FillRepositoryWithData();

                //    GridPrincipal.Children.Add(new Products());
                //    break;
                //case 1:
                //    GridPrincipal.Children.Clear();
                //    GridPrincipal.Children.Add(new UserControlEscolha());
                //    break;
                default:
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (150 + (60 * index)), 0, 0);
        }
    }
}
