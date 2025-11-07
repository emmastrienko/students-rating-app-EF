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

            foreach (var r in ratings)
            {
                Console.WriteLine($"{r.Student?.FirstName} {r.Student?.LastName} - {r.Subject?.SubjectName} - {r.RatingValue}/{r.Subject?.MaxRating} (Teacher: {r.Subject?.Teacher?.FirstName} {r.Subject?.Teacher?.LastName})");
            }
        }
    }
}
