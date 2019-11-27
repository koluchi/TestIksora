using EghteenPlus.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EghteenPlus.Models
{
    public class Product: IProduct
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Descr { get; set; }
        public decimal Price { get; set; }
    }
}