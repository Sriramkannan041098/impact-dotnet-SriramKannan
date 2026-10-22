using EduSphere.AcademicsService.Models;
namespace EduSphere.AcademicsService.Repositories;
public interface IStudentRepository
{
    Task<List<Student>> GetAllAsync(CancellationToken ct);
    Task<Student?> GetByIdAsync(int id, CancellationToken ct);
    Task<Student> AddAsync(Student student, CancellationToken ct);
    Task<bool> UpdateAsync(Student student, CancellationToken ct);
    Task<bool> DeleteAsync(int id, CancellationToken ct);
}
