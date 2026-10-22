using EduSphere.AcademicsService.DTOs;
using EduSphere.AcademicsService.Models;
using EduSphere.AcademicsService.Repositories;
namespace EduSphere.AcademicsService.Services;
public sealed class TeacherService(ITeacherRepository repository) : ITeacherService
{
    public async Task<IReadOnlyList<TeacherDto>> GetAllAsync(CancellationToken ct) => (await repository.GetAllAsync(ct)).Select(Map).ToList();
    public async Task<TeacherDto?> GetByIdAsync(int id, CancellationToken ct) { var x = await repository.GetByIdAsync(id, ct); return x is null ? null : Map(x); }
    public async Task<TeacherDto> CreateAsync(CreateTeacherRequest r, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(r.FullName) || string.IsNullOrWhiteSpace(r.Email) || !r.Email.Contains('@')) throw new ArgumentException("Valid teacher name and email are required.");
        return Map(await repository.AddAsync(new Teacher { FullName = r.FullName.Trim(), Email = r.Email.Trim(), UserId = r.UserId }, ct));
    }
    public async Task<bool> UpdateAsync(int id, UpdateTeacherRequest r, CancellationToken ct)
    {
        var x = await repository.GetByIdAsync(id, ct); if (x is null) return false;
        if (string.IsNullOrWhiteSpace(r.FullName) || string.IsNullOrWhiteSpace(r.Email)) throw new ArgumentException("Teacher name and email are required.");
        x.FullName = r.FullName.Trim(); x.Email = r.Email.Trim();
        await repository.SaveAsync(x, ct); return true;
    }
    public Task<bool> DeleteAsync(int id, CancellationToken ct) => repository.DeleteAsync(id, ct);
    private static TeacherDto Map(Teacher x) => new(x.Id, x.FullName, x.Email);
}
