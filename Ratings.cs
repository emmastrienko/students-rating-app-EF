using System;

namespace StudentRatingEF.Models
{
    public class Rating
    {
        public int RatingId { get; set; }

        // FK to Student
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;  

        // FK to Subject
        public int SubjectId { get; set; }
        public Subject Subject { get; set; } = null!;  

        public string RatingMonth { get; set; } = string.Empty;

        public int RatingValue { get; set; }   
    }
}
