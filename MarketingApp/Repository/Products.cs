using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;


namespace MarketingApp.Repository
{
    public class ProductRepository
    {
        private ObservableCollection<EProduct> products;

        public ProductRepository()
        {
            products = new ObservableCollection<EProduct>
            { 
            new EProduct {Id=1, Name="name1", CreatedAt=Convert.ToDateTime("2019-10-10") },
            new EProduct {Id=1, Name="name2", CreatedAt=Convert.ToDateTime("2019-11-10") },
            new EProduct {Id=1 }
            };
        }
        public ObservableCollection<EProduct> GetProducts()
        {
            return products;
        }
    }
}
