using System;
using System.Linq;
using StudentRatingEF;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

class Program
{
    static void Main()
    {
        // Load environment variables from .env file
        Env.Load("../.env");
        using (var context = new AppDbContext())
        {
            var ratings = context.Ratings
                                 .Include(r => r.Student)
                                 .Include(r => r.Subject)
                                 .ThenInclude(s => s.Teacher)
                                 .ToList();

            var ratingsByStudent = ratings.GroupBy(r => r.Student)
                                          .OrderBy(g => g.Key.FirstName)
                                          .ToList();

            foreach (var studentGroup in ratingsByStudent)
            {
                Console.WriteLine($"Student: {studentGroup.Key?.FirstName} {studentGroup.Key?.LastName}");
                Console.WriteLine($"Number of ratings: {studentGroup.Count()}");
                foreach (var rating in studentGroup)
                {
                    Console.WriteLine($"  - {rating.Subject?.SubjectName}: {rating.RatingValue}/{rating.Subject?.MaxRating} (Teacher: {rating.Subject?.Teacher?.FirstName} {rating.Subject?.Teacher?.LastName})");
                }
                Console.WriteLine();
            }
        }
    }
}
