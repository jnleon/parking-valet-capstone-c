using System.ComponentModel.DataAnnotations;

namespace Capstone.Models
{
    public class Vehicle
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Max length for license plate is 10.")]
        public string LicensePlate { get; set; }
        [Required]
        public int PatronId { get; set; }
        [Required]
        public int ValetId { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Max length for vehicle make is 20.")]
        public string VehicleMake { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Max length for vehicle model is 20.")]
        public string VehicleModel {get; set;}
        [Required]
        [MaxLength(30, ErrorMessage = "Max length for vehicle VIN is 30.")]
        public string VehicleVIN { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Max length for vehicle color is 20.")]
        public string VehicleColor { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Max length for parking status name is 30.")]
        public string ParkingStatus { get; set; }
        
        public Vehicle()
        {

        }

        public Vehicle (string licensePlate, int patronId, int valetId, string vehicleMake, string vehicleModel, string vehicleVIN, string vehicleColor, string parkingStatus)
        {
            LicensePlate = licensePlate;
            PatronId = patronId;
            ValetId = valetId;
            VehicleMake = vehicleMake;
            VehicleModel = vehicleModel;
            VehicleVIN = vehicleVIN;
            VehicleColor = vehicleColor;
            ParkingStatus = parkingStatus;
        }    
    }
}
