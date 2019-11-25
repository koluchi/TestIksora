using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EghteenPlus.Models
{
    public class CartItem : IEquatable<CartItem>
    {
        public int Quantity { get; set; }
        public Product Prod { get; } = null;
        
        public decimal TotalPrice
        {
            get { return Prod.Price * Quantity; }
        }

        public CartItem(Product product)
        {
            this.Prod = product;
        }

        public bool Equals(CartItem item)
        {
            return item.Prod.Id == this.Prod.Id;
        }
    }
    
}