using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EghteenPlus.Contracts;
using EghteenPlus.DA;
using EghteenPlus.Models;
using EntityState = System.Data.Entity.EntityState;

namespace EghteenPlus.Controllers
{
    public class ProductsController : Controller
    {
        private IDataService _dataService;
        public ProductsController(IDataService dataService)
        {
            _dataService = dataService;
        }

        // GET: Products
        public ActionResult Index(string sort = null, decimal from = 0, decimal to = decimal.MaxValue)
        {
            var products = _dataService.GetProducts(from, to).ToList();
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
            var product =_dataService.GetProduct(Id);
            Cart.Instance.AddItem(product, count);
        }
    }
}
