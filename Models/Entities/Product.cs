using System;

namespace DAL.Entities
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public int MerchantId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}