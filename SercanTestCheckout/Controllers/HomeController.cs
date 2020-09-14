using SercanTestCheckout.Helpers;
using SercanTestCheckout.Models;
using SercanTestCheckout.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SercanTestCheckout.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MarketDBEntities _db = new MarketDBEntities();
            var indexViewModel = new IndexViewModel();
            var productViewModel = new ProductViewModel();
            BasketViewModel basketViewModel = new BasketViewModel();
            if (Session["basket"] == null)
            {
                productViewModel.Products = (from p in _db.C_Products select new Product() { Name = p.Name, Id = p.Id, Description = p.Description, Price = (int)p.Price });
            }
            else
            {
                productViewModel.Products = (from p in _db.C_Products select new Product() { Name = p.Name, Id = p.Id, Description = p.Description, Price = (int)p.Price });
                basketViewModel.Products = (List<Product>)Session["basket"];
                var basketLast = DataHelper.CalculateTotalPrice(basketViewModel);
                basketViewModel = basketLast;
            }           
            
            indexViewModel.ProductViewModel = productViewModel;
            indexViewModel.BasketViewModel = basketViewModel;
            return View(indexViewModel);
        }

        public ActionResult AddToBasket(short productId)
        {
            if (Session["basket"] == null)
            {
                List<Product> basket = new List<Product>();
                MarketDBEntities _db = new MarketDBEntities();
                var productSelected = (from p in _db.C_Products where p.Id == productId select new Product() { Name = p.Name, Id = p.Id, Description = p.Description, Price = (int)p.Price , Amount = 1 }).FirstOrDefault();
                var existedProduct = basket.FirstOrDefault(x => x.Id == productSelected.Id);
                if (existedProduct != null)
                {
                    existedProduct.Amount += 1;
                }
                basket.Add(productSelected);
                Session["basket"] = basket;
                return Redirect("Index");
            }
            else
            {
                List<Product> basket = (List<Product>)Session["basket"];
                MarketDBEntities _db = new MarketDBEntities();
                var productSelected = (from p in _db.C_Products where p.Id == productId select new Product() { Name = p.Name, Id = p.Id, Description = p.Description, Price = (int)p.Price, Amount = 1 }).FirstOrDefault();
                var existedProduct = basket.FirstOrDefault(x => x.Id == productSelected.Id);
                if (existedProduct != null)
                {
                    existedProduct.Amount += 1;
                }
                else
                {
                    basket.Add(productSelected);
                    Session["basket"] = basket;
                }
                return Redirect("Index");
            }
           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}