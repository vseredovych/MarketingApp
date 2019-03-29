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
            new EProduct {Id=1, Name="name1", CreatedAt=Convert.ToDateTime("2019-10-10"), MerchantId=1, Price=3999, Status="Present"},
            new EProduct {Id=2, Name="name1", CreatedAt=Convert.ToDateTime("2019-10-10"), MerchantId=1, Price=3999, Status="Present"},
            new EProduct {Id=3, Name="name1", CreatedAt=Convert.ToDateTime("2019-10-10"), MerchantId=1, Price=3999, Status="Present"},
            new EProduct {Id=4, Name="name1", CreatedAt=Convert.ToDateTime("2019-10-10"), MerchantId=1, Price=3999, Status="Present"},
            new EProduct {Id=5, Name="name1", CreatedAt=Convert.ToDateTime("2019-10-10")},
            new EProduct {Id=6, Name="name1", CreatedAt=Convert.ToDateTime("2019-10-10")},
            new EProduct {Id=7, Name="name1", CreatedAt=Convert.ToDateTime("2019-10-10")},
            new EProduct {Id=8, Name="name1", CreatedAt=Convert.ToDateTime("2019-10-10")},
            new EProduct {Id=9, Name="name1", CreatedAt=Convert.ToDateTime("2019-10-10"), MerchantId=1, Price=3999, Status="Present"},
            new EProduct {Id=10, Name="name1", CreatedAt=Convert.ToDateTime("2019-10-10"), MerchantId=1, Price=3999, Status="Present"},
            new EProduct {Id=11, Name="name1", CreatedAt=Convert.ToDateTime("2019-10-10"), MerchantId=1, Price=3999, Status="Present"},
            new EProduct {Id=12, Name="name1", CreatedAt=Convert.ToDateTime("2019-10-10"), MerchantId=1, Price=3999, Status="Present"},
            new EProduct {Id=13, Name="name1", CreatedAt=Convert.ToDateTime("2019-10-10")},
            new EProduct {Id=14, Name="name1", CreatedAt=Convert.ToDateTime("2019-10-10")},
            new EProduct {Id=15, Name="name1", CreatedAt=Convert.ToDateTime("2019-10-10")},
            new EProduct {Id=16, Name="name1", CreatedAt=Convert.ToDateTime("2019-10-10")},
            new EProduct {Id=17 }
            };
        }
        public ObservableCollection<EProduct> GetProducts()
        {
            return products;
        }
    }
}
