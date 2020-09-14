using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SercanTestCheckout.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get; set; }
    }
}