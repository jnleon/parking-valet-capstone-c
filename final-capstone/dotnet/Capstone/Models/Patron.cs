using System.ComponentModel.DataAnnotations;

namespace Capstone.Models
{
    public class Patron
    {
        [Required]
        public int PatronId { get; set; }
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

        public Patron()
        {

        }

        public Patron(int patronId, int userId, string firstName, string lastName, string phoneNumber, string emailAddress)
        {
            PatronId = patronId;
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
        }
    }
}