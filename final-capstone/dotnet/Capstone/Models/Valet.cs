using System.ComponentModel.DataAnnotations;

namespace Capstone.Models
{
    public class Valet
    {
        [Required]
        public int ValetId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Max length for first name is 50.")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Max length for last name is 50.")]
        public string LastName { get; set; }

        public Valet()
        {

        }

        public Valet(int valetId, int userId, string firstName, string lastName)
        {
            ValetId = valetId;
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}