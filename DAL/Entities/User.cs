﻿using System;

namespace DAL.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}