using EghteenPlus.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EghteenPlus.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; private set; }

        public static readonly Cart Instance;

        static Cart()
        {
            if (HttpContext.Current.Session["ASPNETEghteenPlusCart"] == null)
            {
                Instance = new Cart();
                Instance.Items = new List<CartItem>();
                HttpContext.Current.Session["ASPNETEghteenPlusCart"] = Instance;
            }
            else
            {
                Instance = (Cart)HttpContext.Current.Session["ASPNETEghteenPlusCart"];
            }
        }

        protected Cart() { }

        public void AddItem(Product product, int count)
        {
            CartItem newItem = new CartItem(product);

            if (Items.Contains(newItem))
            {
                foreach (CartItem item in Items)
                {
                    if (item.Equals(newItem))
                    {
                        item.Quantity += count;
                        return;
                    }
                }
            }
            else
            {
                newItem.Quantity = count;
                Items.Add(newItem);
            }
        }

        public void SetItemQuantity(Product product, int quantity)
        {
            if (quantity == 0)
            {
                RemoveItem(product);
                return;
            }

            CartItem updatedItem = new CartItem(product);

            foreach (CartItem item in Items)
            {
                if (item.Equals(updatedItem))
                {
                    item.Quantity = quantity;
                    return;
                }
            }
        }

        public void RemoveItem(Product product)
        {
            CartItem removedItem = new CartItem(product);
            Items.Remove(removedItem);
        }

        public decimal GetSubTotal()
        {
            decimal subTotal = 0;
            foreach (CartItem item in Items)
                subTotal += item.TotalPrice;

            return subTotal;
        }
    }
}