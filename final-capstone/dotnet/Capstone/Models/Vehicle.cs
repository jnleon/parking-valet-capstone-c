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
        [MaxLength(20, ErrorMessage = "Max length for vehicle make is 20.")]
        public string VehicleMake { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Max length for vehicle model is 20.")]
        public string VehicleModel {get; set;}
        
        [MaxLength(30, ErrorMessage = "Max length for vehicle VIN is 30.")]
        public string VehicleVIN { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Max length for vehicle color is 20.")]
        public string VehicleColor { get; set; }
        
        [MaxLength(30, ErrorMessage = "Max length for parking status name is 30.")]
        public string ParkingStatus { get; set; }
        
        public Vehicle()
        {

        }

        public Vehicle (string licensePlate, int patronId, string vehicleMake, string vehicleModel, string vehicleColor, string parkingStatus)
        {
            LicensePlate = licensePlate;
            PatronId = patronId;            
            VehicleMake = vehicleMake;
            VehicleModel = vehicleModel;            
            VehicleColor = vehicleColor;
            ParkingStatus = parkingStatus;
        }     
    } public class NewVehicle {
        [Required]
        [MaxLength(10, ErrorMessage = "Max length for license plate is 10.")]
        public string LicensePlate { get; set; }
        [Required]        
        public int ValetId { get; set; }
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
        [MaxLength(50, ErrorMessage = "Max length for email address is 50.")]
        public string PatronEmail { get; set; }
        
    }
}
