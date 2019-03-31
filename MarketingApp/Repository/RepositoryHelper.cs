using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using MarketingApp.Repository;

namespace MarketingApp.Repository
{
    public static class RepositoryHelper
    {

        static public UserRepository userRepository = new UserRepository();
        static public ProductRepository productRepository = new ProductRepository();

        static public ObservableCollection<EProduct> GetProducts()
        {
            return productRepository.GetProducts();
        }

        static public ObservableCollection<EUser> GetUsers()
        {
            return userRepository.GetUsers();
        }
    }
}
