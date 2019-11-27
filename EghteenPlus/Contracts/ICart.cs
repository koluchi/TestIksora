using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EghteenPlus.Contracts
{
    public interface ICart
    {
        List<ICartItem> Items { get; }

        void AddItem(IProduct product, int count);
        void SetItemQuantity(IProduct product, int quantity);
        void RemoveItem(IProduct product);
        void RemoveAll();
        decimal GetSubTotal();
    }
}
