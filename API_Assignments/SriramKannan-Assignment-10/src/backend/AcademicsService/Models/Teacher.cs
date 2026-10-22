namespace EduSphere.AcademicsService.Models;
public sealed class Teacher
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public string FullName { get; set; } = "";
    public string Email { get; set; } = "";
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}
