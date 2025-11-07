using System;
using System.Collections.Generic;

namespace StudentRatingEF.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<Rating>? Ratings { get; set; }
    }
}