﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaOnLine.Models
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
