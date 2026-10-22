using EduSphere.AcademicsService.DTOs;
namespace EduSphere.AcademicsService.Services;
public interface ITeacherService
{
    Task<IReadOnlyList<TeacherDto>> GetAllAsync(CancellationToken ct);
    Task<TeacherDto?> GetByIdAsync(int id, CancellationToken ct);
    Task<TeacherDto> CreateAsync(CreateTeacherRequest request, CancellationToken ct);
    Task<bool> UpdateAsync(int id, UpdateTeacherRequest request, CancellationToken ct);
    Task<bool> DeleteAsync(int id, CancellationToken ct);
}
