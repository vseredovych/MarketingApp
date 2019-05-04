using System.Collections.ObjectModel;
using System.Collections.Generic;
using DAL.Operations;
using DAL.Entities;
using DAL.Interfaces;

namespace Models.Collections
{
    public class ProductsCollections : IEntityCollection<Product>
    {
        private List<Product> products;
        private ProductsOperations productOperations;
        //private const int EntityTablesCount = 6;

        public ProductsCollections()
        {
            productOperations = new ProductsOperations();
            products = new List<Product>();
            products = productOperations.GetAll();
        }

        public void Add(Product product)
        {
            productOperations.Insert(product);
            products.Clear();
            products = productOperations.GetAll();
        }
        public void Update(Product product)
        {
            productOperations.Update(product);
            products.Clear();
            products = productOperations.GetAll();
        }
        public void Delete(int id)
        {
            productOperations.Delete((int)products[id].Id);
            products.RemoveAt(id);
        }

        public List<Product> GetAll()
        {
            return products;
        }
        public Product GetByID(int id)
        {
            return products[id];
        }
        public int GetEntitiesCount()
        {
            return products.Count;
        }
        //public int GetEntityTablesCount()
        //{
        //    return EntityTablesCount;
        //}
    }
}
