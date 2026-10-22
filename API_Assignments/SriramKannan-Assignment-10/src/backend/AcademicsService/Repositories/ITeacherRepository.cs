using EduSphere.AcademicsService.Models;
namespace EduSphere.AcademicsService.Repositories;
public interface ITeacherRepository
{
    Task<List<Teacher>> GetAllAsync(CancellationToken ct);
    Task<Teacher?> GetByIdAsync(int id, CancellationToken ct);
    Task<Teacher> AddAsync(Teacher entity, CancellationToken ct);
    Task SaveAsync(Teacher entity, CancellationToken ct);
    Task<bool> DeleteAsync(int id, CancellationToken ct);
}
