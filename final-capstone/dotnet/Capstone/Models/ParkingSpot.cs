using System.ComponentModel.DataAnnotations;

namespace Capstone.Models
{
    public class ParkingSpot
    {
        public int ParkingSpotId { get; set; }
        
        [Required]
        public bool IsOccupied { get; set; }

        public ParkingSpot()
        {

        }

        public ParkingSpot(bool isOccupied)
        {
            IsOccupied = isOccupied;
        }
    }
}