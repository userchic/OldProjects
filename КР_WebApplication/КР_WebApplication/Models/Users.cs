﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CPWebApplication.Models
{
    public class Users
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fatname { get; set; }
        public DateTime RegDate { get; set; }
        public string Role { get; set; }
        public int Class { get; set; }
        public int ID { get; set; }
    }
}