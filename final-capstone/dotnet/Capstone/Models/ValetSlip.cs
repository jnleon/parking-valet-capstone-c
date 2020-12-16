using System;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Models
{
    public class ValetSlip
    {
        [Required]
        public int TicketId { get; set; }
        
        [Required]
        public int ValetId { get; set; }
        
        [Required]
        [MaxLength(10, ErrorMessage = "Max length for license plate is 10.")]
        public string LicensePlate { get; set; }
        
        [Required]
        public int ParkingSpotId { get; set; }
        
        public DateTime Date { get; set; }
        
        [Required]
        public DateTime TimeIn { get; set; }
        
        public DateTime TimeOut { get; set; }
        
        public decimal AmountOwed { get; set; }
        
        [Required]
        [MaxLength(30, ErrorMessage = "Max length for parking status name is 30.")]
        public string ParkingStatus { get; set; }

        public ValetSlip()
        {

        }

        public ValetSlip(int ticketId, int valetId, string licensePlate, int parkingSpotId, DateTime date, DateTime timeIn, DateTime timeOut, decimal amountOwed, string parkingStatus)
        {
            TicketId = ticketId;
            ValetId = valetId;
            LicensePlate = licensePlate;
            ParkingSpotId = parkingSpotId;
            Date = date;
            TimeIn = timeIn;
            TimeOut = timeOut;
            AmountOwed = amountOwed;
            ParkingStatus = parkingStatus;
        }
    }
}