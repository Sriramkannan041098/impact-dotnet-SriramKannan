namespace EduSphere.AcademicsService.DTOs;
public sealed record TeacherDto(int Id, string FullName, string Email);
public sealed record CreateTeacherRequest(string FullName, string Email, int? UserId);
public sealed record UpdateTeacherRequest(string FullName, string Email);
