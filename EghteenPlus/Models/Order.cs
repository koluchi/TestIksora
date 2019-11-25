using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EghteenPlus.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Number { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public byte[] UserAvatar { get; set; }
        public string UserComment { get; set; }
    }
}