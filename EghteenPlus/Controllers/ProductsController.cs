using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EghteenPlus.DA;
using EghteenPlus.Models;
using EntityState = System.Data.Entity.EntityState;

namespace EghteenPlus.Controllers
{
    public class ProductsController : Controller
    {
        private EPContext db = new EPContext();

        // GET: Products
        public ActionResult Index(string sort = null, decimal from = 0, decimal to = decimal.MaxValue)
        {
            var products = db.Products.Where(w => w.Price > from && w.Price < to).ToList();
            if(sort != null)
            {
                System.Web.HttpContext.Current.Session["ASPNETEghteenPlusProductSort"] = sort;
            }
            sort = (string)System.Web.HttpContext.Current.Session["ASPNETEghteenPlusProductSort"];
            switch (sort)
            {
                case "price":
                    products = products.OrderBy(o => o.Price).ToList();
                    ViewBag.sort = "name";
                    break;
                default:
                    products = products.OrderBy(o => o.Name).ToList();
                    ViewBag.sort = "price";
                    break;
            }
            return View(products);
        }

        [HttpPost]
        public void AddCartItem(Guid Id, int count)
        {
            var product = db.Products.Single<Product>(s => s.Id == Id);
            Cart.Instance.AddItem(product, count);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
