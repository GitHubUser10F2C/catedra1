using System.ComponentModel.DataAnnotations;

namespace catedra1.Src.DTOs
{
    public class UserDto
    {
        public string Rut { get; set; } = string.Empty;
        [StringLength(100, MinimumLength = 3,
        ErrorMessage = "Name must be between 3 and 100 characters.")]
        public string Name { get; set; } = string.Empty;
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;
        [RegularExpression(@"male|female|other|prefer not to say",
        ErrorMessage = "Gender must be 'male', 'female', 'other', or 'prefer not to say'.")]
        public string Gender { get; set; } = string.Empty;
        [PastDate]
        public DateTime Birthday { get; set; }
    }
}