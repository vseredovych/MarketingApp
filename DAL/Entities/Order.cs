using System;

namespace DAL.Entities
{
    public class Order
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
