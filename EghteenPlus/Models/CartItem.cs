using EghteenPlus.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EghteenPlus.Models
{
    public class CartItem : ICartItem
    {
        public int Quantity { get; set; }
        public IProduct Prod { get; }
        
        public decimal TotalPrice
        {
            get { return Prod.Price * Quantity; }
        }

        public CartItem(IProduct product)
        {
            Prod = product;
        }

        public bool Equals(ICartItem item)
        {
            return item.Prod.Id == Prod.Id;
        }
    }
    
}