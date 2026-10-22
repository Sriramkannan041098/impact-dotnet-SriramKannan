using EduSphere.AcademicsService.Models;
namespace EduSphere.AcademicsService.Repositories;
public interface ICourseRepository
{
    Task<List<Course>> GetAllAsync(CancellationToken ct);
    Task<Course?> GetByIdAsync(int id, CancellationToken ct);
    Task<Course> AddAsync(Course entity, CancellationToken ct);
    Task SaveAsync(Course entity, CancellationToken ct);
    Task<bool> DeleteAsync(int id, CancellationToken ct);
}
