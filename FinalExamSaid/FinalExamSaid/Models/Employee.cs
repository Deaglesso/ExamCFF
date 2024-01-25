using FinalExamSaid.Models.Common;

namespace FinalExamSaid.Models
{
    public class Employee : BaseModel
    {
        public string Name { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string? FbLink { get; set; }
        public string? TwLink { get; set; }
        public string? IgLink { get; set; }
        public string? LiLink { get; set; }

    }
}
