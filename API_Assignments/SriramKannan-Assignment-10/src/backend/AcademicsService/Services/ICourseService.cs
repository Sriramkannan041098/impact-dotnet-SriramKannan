using EduSphere.AcademicsService.DTOs;
namespace EduSphere.AcademicsService.Services;
public interface ICourseService
{
    Task<IReadOnlyList<CourseDto>> GetAllAsync(CancellationToken ct);
    Task<CourseDto?> GetByIdAsync(int id, CancellationToken ct);
    Task<CourseDto> CreateAsync(CreateCourseRequest request, CancellationToken ct);
    Task<bool> UpdateAsync(int id, UpdateCourseRequest request, CancellationToken ct);
    Task<bool> DeleteAsync(int id, CancellationToken ct);
}
