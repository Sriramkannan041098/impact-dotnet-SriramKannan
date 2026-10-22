using EduSphere.AcademicsService.DTOs;
using EduSphere.AcademicsService.Models;
using EduSphere.AcademicsService.Repositories;
namespace EduSphere.AcademicsService.Services;
public sealed class CourseService(ICourseRepository repository) : ICourseService
{
    public async Task<IReadOnlyList<CourseDto>> GetAllAsync(CancellationToken ct) => (await repository.GetAllAsync(ct)).Select(Map).ToList();
    public async Task<CourseDto?> GetByIdAsync(int id, CancellationToken ct) { var x = await repository.GetByIdAsync(id, ct); return x is null ? null : Map(x); }
    public async Task<CourseDto> CreateAsync(CreateCourseRequest r, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(r.CourseCode) || string.IsNullOrWhiteSpace(r.Title)) throw new ArgumentException("Course code and title are required.");
        return Map(await repository.AddAsync(new Course { CourseCode = r.CourseCode.Trim(), Title = r.Title.Trim(), Description = r.Description, TeacherId = r.TeacherId }, ct));
    }
    public async Task<bool> UpdateAsync(int id, UpdateCourseRequest r, CancellationToken ct)
    {
        var x = await repository.GetByIdAsync(id, ct); if (x is null) return false;
        if (string.IsNullOrWhiteSpace(r.Title)) throw new ArgumentException("Course title is required.");
        x.Title = r.Title.Trim(); x.Description = r.Description; x.TeacherId = r.TeacherId;
        await repository.SaveAsync(x, ct); return true;
    }
    public Task<bool> DeleteAsync(int id, CancellationToken ct) => repository.DeleteAsync(id, ct);
    private static CourseDto Map(Course x) => new(x.Id, x.CourseCode, x.Title, x.Description, x.TeacherId);
}
