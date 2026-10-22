namespace EduSphere.ReportingService.Models;
public sealed class EnrollmentSummary
{
    public int Id { get; set; }
    public string CourseCode { get; set; } = "";
    public string CourseTitle { get; set; } = "";
    public string? TeacherName { get; set; }
    public int TotalStudents { get; set; }
    public int ActiveEnrollments { get; set; }
    public DateTime SnapshotUtc { get; set; }
}
