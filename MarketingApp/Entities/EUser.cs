using System;

namespace DAL.Entities
{
    class EUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public bool IsActive { get; set; }

    }
}
