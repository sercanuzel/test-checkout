using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SercanTestCheckout.Models
{
    public class Deal
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public int DiscountAmountPercent { get; set; }
        public int DiscountAmountPrice { get; set; }
    }
}