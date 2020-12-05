using System.ComponentModel.DataAnnotations;

namespace Capstone.Models
{
    public class ParkingStatus
    {
        [Required]
        public int ParkingStatusId { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Max length for parking status name is 30.")]
        public string ParkingStatusName { get; set; }

        public ParkingStatus()
        {

        }

        public ParkingStatus(int parkingStatusId, string parkingStatusName)
        {
            ParkingStatusId = parkingStatusId;
            ParkingStatusName = parkingStatusName;
        }
    }
}