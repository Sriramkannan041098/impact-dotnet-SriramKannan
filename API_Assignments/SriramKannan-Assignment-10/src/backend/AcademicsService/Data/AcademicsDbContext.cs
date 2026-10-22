using EduSphere.AcademicsService.Models;
using Microsoft.EntityFrameworkCore;

namespace EduSphere.AcademicsService.Data;
public sealed class AcademicsDbContext(DbContextOptions<AcademicsDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().HasIndex(x => x.StudentNumber).IsUnique();
        modelBuilder.Entity<Course>().HasIndex(x => x.CourseCode).IsUnique();
        modelBuilder.Entity<Enrollment>().HasIndex(x => new { x.StudentId, x.CourseId }).IsUnique();
        modelBuilder.Entity<Course>().HasOne(x => x.Teacher).WithMany(x => x.Courses).HasForeignKey(x => x.TeacherId);
        modelBuilder.Entity<Enrollment>().HasOne(x => x.Student).WithMany().HasForeignKey(x => x.StudentId);
        modelBuilder.Entity<Enrollment>().HasOne(x => x.Course).WithMany(x => x.Enrollments).HasForeignKey(x => x.CourseId);

        modelBuilder.Entity<Teacher>().HasData(new Teacher { Id = 1, FullName = "Demo Teacher", Email = "teacher@edusphere.local", UserId = null });
        modelBuilder.Entity<Course>().HasData(new Course { Id = 1, CourseCode = "CS101", Title = "Introduction to Computing", Description = "Seed course", TeacherId = 1 });
        modelBuilder.Entity<Student>().HasData(new Student { Id = 1, StudentNumber = "STU-1001", FullName = "Demo Student", Email = "student@edusphere.local", IsActive = true });
    }
}
