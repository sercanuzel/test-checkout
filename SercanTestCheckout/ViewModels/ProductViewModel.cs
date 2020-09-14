using SercanTestCheckout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SercanTestCheckout.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}