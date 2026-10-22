namespace EduSphere.AcademicsService.DTOs;
public sealed record StudentDto(int Id, string StudentNumber, string FullName, string Email, DateTime? DateOfBirth, bool IsActive);
public sealed record CreateStudentRequest(string StudentNumber, string FullName, string Email, DateTime? DateOfBirth);
public sealed record UpdateStudentRequest(string FullName, string Email, DateTime? DateOfBirth, bool IsActive);
