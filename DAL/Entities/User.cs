using System;

namespace DAL.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Gmail { get; set; }
        public string Password { get; set; }
        public int AccessLvl { get; set; }
    }
}