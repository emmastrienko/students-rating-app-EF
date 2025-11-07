using System.Collections.Generic;

namespace StudentRatingEF.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public int MaxRating { get; set; }

        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        public ICollection<Rating>? Ratings { get; set; }
    }
}