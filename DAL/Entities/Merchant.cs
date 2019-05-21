using System;

namespace DAL.Entities
{
    public class Merchant
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Salary { get; set; }
        public string CurrentCity { get; set; }
    }
}
