using EduSphere.AcademicsService.DTOs;
using EduSphere.AcademicsService.Models;
using EduSphere.AcademicsService.Repositories;
namespace EduSphere.AcademicsService.Services;
public sealed class StudentService(IStudentRepository repository) : IStudentService
{
    public async Task<IReadOnlyList<StudentDto>> GetAllAsync(CancellationToken ct) =>
        (await repository.GetAllAsync(ct)).Select(Map).ToList();
    public async Task<StudentDto?> GetByIdAsync(int id, CancellationToken ct) {
        var entity = await repository.GetByIdAsync(id, ct); return entity is null ? null : Map(entity);
    }
    public async Task<StudentDto> CreateAsync(CreateStudentRequest request, CancellationToken ct) {
        if (string.IsNullOrWhiteSpace(request.StudentNumber) || string.IsNullOrWhiteSpace(request.FullName) || string.IsNullOrWhiteSpace(request.Email))
            throw new ArgumentException("Student number, full name and email are required.");
        var entity = await repository.AddAsync(new Student { StudentNumber = request.StudentNumber.Trim(), FullName = request.FullName.Trim(), Email = request.Email.Trim(), DateOfBirth = request.DateOfBirth }, ct);
        return Map(entity);
    }
    public async Task<bool> UpdateAsync(int id, UpdateStudentRequest request, CancellationToken ct) {
        var entity = await repository.GetByIdAsync(id, ct); if (entity is null) return false;
        entity.FullName = request.FullName.Trim(); entity.Email = request.Email.Trim(); entity.DateOfBirth = request.DateOfBirth; entity.IsActive = request.IsActive;
        return await repository.UpdateAsync(entity, ct);
    }
    public Task<bool> DeleteAsync(int id, CancellationToken ct) => repository.DeleteAsync(id, ct);
    private static StudentDto Map(Student x) => new(x.Id, x.StudentNumber, x.FullName, x.Email, x.DateOfBirth, x.IsActive);
}
