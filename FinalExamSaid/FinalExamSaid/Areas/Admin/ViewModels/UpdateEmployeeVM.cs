﻿using System.ComponentModel.DataAnnotations;

namespace FinalExamSaid.Areas.Admin.ViewModels
{
    public class UpdateEmployeeVM
    {
        [Required]
        [MinLength(3, ErrorMessage = "Minimum length is 3")]
        [MaxLength(50, ErrorMessage = "Maximum length is 50")]
        public string Name { get; set; } = null!;
        [Required]
        [MinLength(3, ErrorMessage = "Minimum length is 3")]
        [MaxLength(50, ErrorMessage = "Maximum length is 50")]
        public string Position { get; set; } = null!;

        [Required]
        public string Image { get; set; } = null!;

        public IFormFile? Photo { get; set; } 

        public string? FbLink { get; set; }
        public string? TwLink { get; set; }
        public string? IgLink { get; set; }
        public string? LiLink { get; set; }
    }
}