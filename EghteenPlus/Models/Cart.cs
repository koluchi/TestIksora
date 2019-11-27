using EghteenPlus.Contracts;
using System.Collections.Generic;
using System.Web;

namespace EghteenPlus.Models
{
    public class Cart: ICart
    {
        public List<ICartItem> Items { get; private set; }

        public static readonly ICart Instance;

        static Cart()
        {
            if (HttpContext.Current.Session["ASPNETEghteenPlusCart"] == null)
            {
                Instance = new Cart();
                ((Cart)Instance).Items = new List<ICartItem>();
                HttpContext.Current.Session["ASPNETEghteenPlusCart"] = Instance;
            }
            else
            {
                Instance = (Cart)HttpContext.Current.Session["ASPNETEghteenPlusCart"];
            }
        }

        protected Cart() { }

        public void AddItem(IProduct product, int count)
        {
            ICartItem newItem = new CartItem(product);

            if (Items.Contains(newItem))
            {
                foreach (ICartItem item in Items)
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

        public void SetItemQuantity(IProduct product, int quantity)
        {
            if (quantity == 0)
            {
                RemoveItem(product);
                return;
            }

            ICartItem updatedItem = new CartItem(product);

            foreach (ICartItem item in Items)
            {
                if (item.Equals(updatedItem))
                {
                    item.Quantity = quantity;
                    return;
                }
            }
        }

        public void RemoveItem(IProduct product)
        {
            ICartItem removedItem = new CartItem(product);
            Items.Remove(removedItem);
        }

        public void RemoveAll()
        {
            Items.Clear();
        }

        public decimal GetSubTotal()
        {
            decimal subTotal = 0;
            foreach (ICartItem item in Items)
                subTotal += item.TotalPrice;

            return subTotal;
        }
    }
}