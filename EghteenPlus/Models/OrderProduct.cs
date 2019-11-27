using EghteenPlus.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EghteenPlus.Models
{
    public class OrderProduct : IOrderProduct
    {
        [Key]
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public virtual IOrder Order { get; set; }
        public virtual IProduct Product { get; set; }
    }
}