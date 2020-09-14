using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SercanTestCheckout.Models
{
    public class CustomerBasket
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
    }
}