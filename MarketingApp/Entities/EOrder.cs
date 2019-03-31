using System;

namespace DAL.Entities
{
    class EOrder
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
