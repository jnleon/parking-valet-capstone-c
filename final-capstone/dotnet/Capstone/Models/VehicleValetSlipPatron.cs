using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class VehicleValetSlipPatron
    {
        [Required]
        public int TicketId { get; set; }

        [Required]
        public int ValetId { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Max length for license plate is 10.")]
        public string LicensePlate { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Max length for parking spot is 10.")]
        public int ParkingSpotId { get; set; }

        //[Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime TimeIn { get; set; }

        public DateTime TimeOut { get; set; }

        public decimal AmountOwed { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Max length for parking status name is 30.")]
        public string ParkingStatus { get; set; }

        [Required]
        public int PatronId { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Max length for vehicle make is 20.")]
        public string VehicleMake { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Max length for vehicle model is 20.")]
        public string VehicleModel { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Max length for vehicle color is 20.")]
        public string VehicleColor { get; set; }

        [Required]
        public int UserId { get; set; }
        
        [Required]
        [MaxLength(50, ErrorMessage = "Max length for first name is 50.")]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(50, ErrorMessage = "Max length for last name is 50.")]
        public string LastName { get; set; }
        
        [Required]
        [MaxLength(10, ErrorMessage = "Max length for phone number is 10.")]
        public string PhoneNumber { get; set; }
        
        [Required]
        [MaxLength(50, ErrorMessage = "Max length for error message is 50.")]
        public string EmailAddress { get; set; }
    }
}
