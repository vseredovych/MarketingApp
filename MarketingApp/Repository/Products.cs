using System;
using System.Collections.ObjectModel;
using DAL.Entities;
using DAL.Helper;
using DAL.Operations;

namespace MarketingApp.Repository
{
    public class ProductRepository
    {
        private ObservableCollection<EProduct> products;
        OProducts dbProducts = new OProducts();

        public ProductRepository()
        {
            products = new ObservableCollection<EProduct>();
        }
        public void FillRepositoryWithData()
        {
            products =  new ObservableCollection<EProduct>(dbProducts.Select());
        }
        public void AddProductToRepository(EProduct product)
        {
            products.Add(product);
        }
        public ObservableCollection<EProduct> GetProducts()
        {
            return products;
        }
    }
}
