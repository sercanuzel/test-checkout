﻿using SercanTestCheckout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SercanTestCheckout.ViewModels
{
    public class BasketViewModel
    {
        public List<Product> Products { get; set; }
        public int TotalPrice { get; set; }
    }
}