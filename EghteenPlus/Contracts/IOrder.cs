using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EghteenPlus.Contracts
{
    public interface IOrder
    {
        Guid Id { get; set; }
        int Number { get; set; }
        DateTime CreateDate { get; set; }
        Guid UserId { get; set; }
        string UserName { get; set; }
        string UserPhone { get; set; }
        byte[] UserAvatar { get; set; }
        string UserComment { get; set; }
    }
}
