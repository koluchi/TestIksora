using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EghteenPlus.Contracts
{
    public interface ICartItem: IEquatable<ICartItem>
    {
        int Quantity { get; set; }
        IProduct Prod { get; }
        decimal TotalPrice { get; }
    }
}
