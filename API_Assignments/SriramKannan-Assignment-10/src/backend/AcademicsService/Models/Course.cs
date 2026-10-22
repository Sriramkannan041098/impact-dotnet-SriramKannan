namespace EduSphere.AcademicsService.Models;
public sealed class Course
{
    public int Id { get; set; }
    public string CourseCode { get; set; } = "";
    public string Title { get; set; } = "";
    public string? Description { get; set; }
    public int? TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
