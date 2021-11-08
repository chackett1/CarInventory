using System.ComponentModel.DataAnnotations;

namespace CarInventory.Models
{
    public class Sale
    {
        public int purchaseID { get; set; }

        [Required]
        [Display(Name = "Sale ID")]
        public int SaleID { get; set; }

        [Required]
        [Display(Name = "Car Name")]
        [StringLength(50)]
        public string CarName { get; set; }

        [Required]
        [Display(Name = "Price")]
        public double? UnitPrice { get; set; }
    }
}