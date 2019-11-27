using EghteenPlus.Contracts;
using EghteenPlus.DA;
using EghteenPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EghteenPlus.Services
{
    public class DataService: IDataService
    {
        private EPContext db;

        public DataService(EPContext context)
        {
            db = context;
        }

        public IEnumerable<IProduct> GetProducts(decimal minPrice, decimal maxPrice)
        {
            return db.Products.Where(w => w.Price > minPrice && w.Price < maxPrice);
        }

        public IProduct GetProduct(Guid Id)
        {
            return db.Products.Single(s => s.Id == Id);
        }

        public void Dispose()
        {
            if(db != null)
            {
                db.Dispose();
            }
        }

        public bool SaveOrder(IOrder order, IEnumerable<IOrderProduct> products)
        {
            try
            {
                db.Orders.Add(order as Order);
                db.OrderProducts.AddRange(products as IEnumerable<OrderProduct>);
                db.SaveChanges();
            }
            catch(Exception e)
            {
                // типа чёт вывели в лог
                return false;
            }
            return true;
        }
    }
}