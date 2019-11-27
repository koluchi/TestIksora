using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EghteenPlus.Contracts
{
    public interface IDataService : IDisposable
    {
        IEnumerable<IProduct> GetProducts(decimal minPrice, decimal maxPrice);
        IProduct GetProduct(Guid Id);
        bool SaveOrder(IOrder order, IEnumerable<IOrderProduct> products);
    }
}
