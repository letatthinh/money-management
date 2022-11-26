using Common.CustomJsonConverters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiLayer.DataTransferObjects.UserGroup
{
    /// <summary>
    /// DTO for creating a new user.
    /// </summary>
    public class CreateUserDto
    {
        /// <summary>
        /// Username.
        /// </summary>
        [Required(ErrorMessage = "Username is required")]
        [MinLength(3, ErrorMessage = "Username must not less than 3 characters")]
        [MaxLength(20, ErrorMessage = "Username must not exceed 20 characters")]
        [RegularExpression(@"[\w.]+", ErrorMessage = "Username must contain only letters, numbers, underscores and dots")]
        public string UserName { get; set; } = null!;

        /// <summary>
        /// Password.
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must not less than 6 characters")]
        [MaxLength(50, ErrorMessage = "Password must not exceed 50 characters")]
        [RegularExpression(
            "(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[~!@#$%^&*()_\\-+={}[\\]|\\:;'\",.<>\\/?]).{0,}",
            ErrorMessage = "Password must contain aleast one lowercase letter, one uppercase letter, one digit and one special character")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        /// <summary>
        /// User's first name.
        /// </summary>
        [Required(ErrorMessage = "User's first name is required")]
        [StringLength(20, ErrorMessage = "User's first name must not exceed 20 characters")]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// User's middle name.
        /// </summary>
        [StringLength(20, ErrorMessage = "User's middle name must not exceed 20 characters")]
        public string? MiddleName { get; set; }

        /// <summary>
        /// User's last name.
        /// </summary>
        [Required(ErrorMessage = "User's last name is required")]
        [StringLength(20, ErrorMessage = "User's last name must not exceed 20 characters")]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// User's birthday.
        /// </summary>
        [Required(ErrorMessage = "User's birthday is required. Correct format is yyyy-mm-dd")]
        [DisplayFormat(DataFormatString = "yyyy-mm-dd")]
        public DateOnly Birthday { get; set; }

        //public ICollection<UserEmail>? Emails { get; set; } = new List<UserEmail>();

        //public ICollection<UserRoles> UserRoles { get; set; } = new List<UserRoles>();
    }
}
