using EghteenPlus.Contracts;
using EghteenPlus.DA;
using EghteenPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EghteenPlus.Controllers
{
    public class OrderController : Controller
    {
        private IDataService _dataService;
        public OrderController(IDataService dataService)
        {
            _dataService = dataService;
        }
        // GET: Order
        public ActionResult Index()
        {
            var model = new OrderCartViewModel() { cart = Cart.Instance };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(OrderCartViewModel orderCart, HttpPostedFileBase upload)
        {
            orderCart.cart = Cart.Instance;
            if (ModelState.IsValid)
            {
                byte[] avatar = null;
                if (upload != null)
                {
                    avatar = new byte[upload.ContentLength];
                    upload.InputStream.Read(avatar, 0, upload.ContentLength);
                }
                var order = new Order()
                {
                    Id = Guid.NewGuid(),
                    UserName = orderCart.UserName,
                    UserPhone = orderCart.UserPhone,
                    UserComment = orderCart.UserComment,
                    UserAvatar = avatar,
                    UserId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                };
                var orderProducts = new List<OrderProduct>();
                foreach (var item in orderCart.cart.Items)
                {
                    orderProducts.Add(new OrderProduct { Id = Guid.NewGuid(), OrderId = order.Id, ProductId = item.Prod.Id, Price = item.Prod.Price, Quantity = item.Quantity });
                }
                _dataService.SaveOrder(order, orderProducts);

                Cart.Instance.RemoveAll();
                
                return Redirect("/Products");
            }
            return View(orderCart);

        }
    }
}