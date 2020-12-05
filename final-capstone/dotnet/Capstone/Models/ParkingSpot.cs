using System.ComponentModel.DataAnnotations;

namespace Capstone.Models
{
    public class ParkingSpot
    {
        [Required]
        [MaxLength(10, ErrorMessage ="Max length for parking spot id is 10.")]
        public string ParkingSpotId { get; set; }
        [Required]
        public bool IsOccupied { get; set; }

        public ParkingSpot()
        {

        }

        public ParkingSpot(string parkingSpotId, bool isOccupied)
        {
            ParkingSpotId = parkingSpotId;
            IsOccupied = isOccupied;
        }
    }
}