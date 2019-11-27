using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EghteenPlus.Contracts
{
    public interface IProduct
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Url { get; set; }
        string Descr { get; set; }
        decimal Price { get; set; }
    }
}
