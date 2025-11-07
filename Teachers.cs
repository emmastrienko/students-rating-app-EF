using System.Collections.Generic;

namespace StudentRatingEF.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }

        public ICollection<Subject>? Subjects { get; set; }
    }
}