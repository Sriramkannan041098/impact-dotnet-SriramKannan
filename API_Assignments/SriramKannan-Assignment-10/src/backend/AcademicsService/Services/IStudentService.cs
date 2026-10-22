using EduSphere.AcademicsService.DTOs;
namespace EduSphere.AcademicsService.Services;
public interface IStudentService
{
    Task<IReadOnlyList<StudentDto>> GetAllAsync(CancellationToken ct);
    Task<StudentDto?> GetByIdAsync(int id, CancellationToken ct);
    Task<StudentDto> CreateAsync(CreateStudentRequest request, CancellationToken ct);
    Task<bool> UpdateAsync(int id, UpdateStudentRequest request, CancellationToken ct);
    Task<bool> DeleteAsync(int id, CancellationToken ct);
}
