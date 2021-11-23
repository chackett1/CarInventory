using System.ComponentModel.DataAnnotations;

namespace CarInventory.Models
{
    public class ArchivedAppointment
    {
        [Key]
        public int ArchivedAppointmentID { get; set; }
        
        [Required]
        [Display(Name = "Customer Name")]
        [StringLength(50)]
        public string ArchivedCustomerName { get; set; }
    
        [Required]
        [Display(Name = "Customer Email")]
        [StringLength(100)]
        public string ArchivedCustomerEmail { get; set; }

        [Required]
        [Display(Name = "Desired Vehicle")]
        [StringLength(100)]
        public string ArchivedDesiredVehicle { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Customer Message")]
        [StringLength(10000)]
        public string ArchivedCustomerMessage { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Comments")]
        [StringLength(10000)]
        public string ArchivedEmployeeComment { get; set; }
    }
}