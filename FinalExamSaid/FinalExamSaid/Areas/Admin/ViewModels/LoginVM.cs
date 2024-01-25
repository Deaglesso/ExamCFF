using System.ComponentModel.DataAnnotations;

namespace FinalExamSaid.Areas.Admin.ViewModels
{
    public class LoginVM
    {
        [Required]
        [MinLength(3, ErrorMessage = "Minimum length is 3")]
        [MaxLength(255, ErrorMessage = "Maximum length is 255")]
        public string UsernameOrEmail { get; set; } = null!;
        [Required]
        [MinLength(8, ErrorMessage = "Minimum length is 8")]
        [MaxLength(50, ErrorMessage = "Maximum length is 50")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        public bool IsRemembered { get; set; }

    }
}
