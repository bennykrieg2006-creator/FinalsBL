using System.ComponentModel.DataAnnotations;

namespace FinalsBL.Models
{


    public class StudentProfile
    {
        public int Id { get; set; }

        [Required, MaxLength(120)]
        public string FullName { get; set; } = string.Empty;

        [Required, MaxLength(120)]
        public string CollegeProgram { get; set; } = string.Empty;

        [Required, MaxLength(30)]
        public string YearInProgram { get; set; } = string.Empty;

        [Required, MaxLength(120)]
        public string FavoriteMajorCourse { get; set; } = string.Empty;

        [Required, MaxLength(120)]
        public string FavoriteElectiveCourse { get; set; } = string.Empty;
    }
}