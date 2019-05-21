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

        ProductsMenu productsMenu;
        MerchantsMenu merchantsMenu;
        UsersMenu usersMenu;
        RootMenu rootMenu;

        public MainMenu()
        {
            productsMenu = new ProductsMenu();
            merchantsMenu = new MerchantsMenu();
            usersMenu = new UsersMenu();
            rootMenu = new RootMenu();
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
                    GridPrincipal.Children.Add(usersMenu);
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(merchantsMenu);
                    break;
                case 3:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(productsMenu);
                    break;
                case 4:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(rootMenu);
                    break;
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
