namespace EduSphere.AcademicsService.DTOs;
public sealed record CourseDto(int Id, string CourseCode, string Title, string? Description, int? TeacherId);
public sealed record CreateCourseRequest(string CourseCode, string Title, string? Description, int? TeacherId);
public sealed record UpdateCourseRequest(string Title, string? Description, int? TeacherId);
