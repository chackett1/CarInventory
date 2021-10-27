using System.ComponentModel.DataAnnotations;

namespace CarInventory.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Customer Email")]
        [StringLength(100)] 
        public string CustomerEmail { get; set; }

        [Required]
        [Display(Name = "Desired Vehicle")]
        [StringLength(100)] 
        public string DesiredVehicle { get; set; }


        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Customer Message")]
        [StringLength(10000)]  
        public string CustomerMessage { get; set; }

    }
}