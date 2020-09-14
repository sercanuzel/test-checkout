using SercanTestCheckout.Models;
using SercanTestCheckout.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SercanTestCheckout.Helpers
{
    public static class DataHelper
    {
        public static BasketViewModel CalculateTotalPrice(BasketViewModel basketViewModel)
        {
            int totalPrice = 0;
            foreach (var product in basketViewModel.Products)
            {
                totalPrice += product.Price;
            }

            basketViewModel.TotalPrice = totalPrice;
            totalPrice = ApplyDiscount(basketViewModel);
            basketViewModel.TotalPrice = totalPrice;

            return basketViewModel;
        }

        public static int ApplyDiscount(BasketViewModel basketViewModel)
        {
            int finalPrice = 0;
            int totalPriceProducts = 0;
            List<Product> basket = basketViewModel.Products;
            
            MarketDBEntities _db = new MarketDBEntities();
            var deals = (from p in _db.C_Deals select new Deal() { Id = p.Id, ProductId = p.ProductId, Amount = (int)p.Amount , DiscountAmountPercent = (int)p.DiscountAmountPercent, DiscountAmountPrice = (int)p.DiscountAmountPrice});
            foreach (var product in basket)
            {
                var existingDeal = deals.FirstOrDefault(x => x.ProductId == product.Id);

                product.TotalPrice =
                    product.Price * product.Amount -
                    (product.Amount / existingDeal.Amount) * existingDeal.DiscountAmountPrice;
                //if (existingDeal.Amount<=product.Amount)
                //{
                //    product.TotalPrice = product.Price * product.Amount - existingDeal.DiscountAmountPrice;
                //}
                //else
                //{
                //    product.TotalPrice = product.Amount*product.Price;
                //}
                
            }

            finalPrice = basket.Sum(x => x.TotalPrice);

            return finalPrice;
        }
    }
}