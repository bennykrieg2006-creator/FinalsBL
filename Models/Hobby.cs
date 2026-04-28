using System.ComponentModel.DataAnnotations;

namespace FinalsBL.Models
{

    public class HobbyItem
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        public string HobbyName { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Description { get; set; }

        public int HoursPerWeek { get; set; }

        [MaxLength(40)]
        public string? SkillLevel { get; set; }

        public bool IsIndoor { get; set; }
    }
}