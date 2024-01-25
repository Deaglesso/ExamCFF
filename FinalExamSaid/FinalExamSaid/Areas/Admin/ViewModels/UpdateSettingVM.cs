using System.ComponentModel.DataAnnotations;

namespace FinalExamSaid.Areas.Admin.ViewModels
{
    public class UpdateSettingVM
    {
        [Required]
        public string Key { get; set; } = null!;
        [Required]
        [MinLength(2,ErrorMessage ="Minimum length is 2")]
        [MaxLength(255, ErrorMessage = "Maximum length is 255")]
        public string Value { get; set; } = null!;
    }
}
