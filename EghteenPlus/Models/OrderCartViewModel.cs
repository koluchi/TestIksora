using EghteenPlus.Contracts;
using System.ComponentModel.DataAnnotations;

namespace EghteenPlus.Models
{
    public class OrderCartViewModel
    {
        public ICart cart { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string UserName { get; set; }
        [Required]
        [RegularExpression("\\d{3}-\\d{3}-\\d{2}-\\d{2}", ErrorMessage = "Phone format XXX-XXX-XX-XX")]
        public string UserPhone { get; set; }

        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string UserComment { get; set; }

    }
}