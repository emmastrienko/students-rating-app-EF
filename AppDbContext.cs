using Microsoft.EntityFrameworkCore;
using StudentRatingEF.Models;

namespace StudentRatingEF
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use environment variable or fall back to default
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map entity names to actual database table names (PostgreSQL uses lowercase)
            modelBuilder.Entity<Student>().ToTable("students");
            modelBuilder.Entity<Teacher>().ToTable("teachers");
            modelBuilder.Entity<Subject>().ToTable("subjects");
            modelBuilder.Entity<Rating>().ToTable("ratings");

            // Configure column names to match database schema
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);
                entity.Property(e => e.StudentId).HasColumnName("student_id");
                entity.Property(e => e.FirstName).HasColumnName("first_name");
                entity.Property(e => e.LastName).HasColumnName("last_name");
                entity.Property(e => e.MiddleName).HasColumnName("middle_name");
                entity.Property(e => e.Address).HasColumnName("address");
                entity.Property(e => e.Phone).HasColumnName("phone");
                entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.TeacherId);
                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
                entity.Property(e => e.FirstName).HasColumnName("first_name");
                entity.Property(e => e.LastName).HasColumnName("last_name");
                entity.Property(e => e.MiddleName).HasColumnName("middle_name");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.SubjectId);
                entity.Property(e => e.SubjectId).HasColumnName("subject_id");
                entity.Property(e => e.SubjectName).HasColumnName("subject_name");
                entity.Property(e => e.MaxRating).HasColumnName("max_rating");
                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => e.RatingId);
                entity.Property(e => e.RatingId).HasColumnName("rating_id");
                entity.Property(e => e.StudentId).HasColumnName("student_id");
                entity.Property(e => e.SubjectId).HasColumnName("subject_id");
                entity.Property(e => e.RatingMonth).HasColumnName("rating_month");
                entity.Property(e => e.RatingValue).HasColumnName("rating_value");
            });
        }
    }
}
