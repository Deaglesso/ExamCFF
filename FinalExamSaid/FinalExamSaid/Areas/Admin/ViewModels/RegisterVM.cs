using System.ComponentModel.DataAnnotations;

namespace FinalExamSaid.Areas.Admin.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [MinLength(3,ErrorMessage ="Minimum length is 3")]
        [MaxLength(50,ErrorMessage = "Maximum length is 50")]
        public string Name { get; set; } = null!;
        [Required]
        [MinLength(3, ErrorMessage = "Minimum length is 3")]
        [MaxLength(50, ErrorMessage = "Maximum length is 50")]
        public string Surname { get; set; } = null!;
        [Required]
        [MinLength(3, ErrorMessage = "Minimum length is 3")]
        [MaxLength(50, ErrorMessage = "Maximum length is 50")]
        public string Username { get; set; } = null!;
        [Required]
        [EmailAddress]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]
        public string Email { get; set; } = null!;
        [Required]
        [MinLength(8, ErrorMessage = "Minimum length is 8")]
        [MaxLength(50, ErrorMessage = "Maximum length is 50")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Required]
        [MinLength(8, ErrorMessage = "Minimum length is 8")]
        [MaxLength(50, ErrorMessage = "Maximum length is 50")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
