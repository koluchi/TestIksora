using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EghteenPlus.Contracts
{
    public interface IOrderProduct
    {
        Guid Id { get; set; }
        Guid OrderId { get; set; }
        Guid ProductId { get; set; }
        decimal Price { get; set; }
        int Quantity { get; set; }

        IOrder Order { get; set; }
        IProduct Product { get; set; }
    }
}
