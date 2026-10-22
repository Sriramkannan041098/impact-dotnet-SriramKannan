using EduSphere.AcademicsService.Data;
using EduSphere.AcademicsService.Models;
using Microsoft.EntityFrameworkCore;
namespace EduSphere.AcademicsService.Repositories;
public sealed class StudentRepository(AcademicsDbContext db) : IStudentRepository
{
    public Task<List<Student>> GetAllAsync(CancellationToken ct) => db.Students.AsNoTracking().OrderBy(x => x.Id).ToListAsync(ct);
    public Task<Student?> GetByIdAsync(int id, CancellationToken ct) => db.Students.FirstOrDefaultAsync(x => x.Id == id, ct);
    public async Task<Student> AddAsync(Student student, CancellationToken ct) { db.Students.Add(student); await db.SaveChangesAsync(ct); return student; }
    public async Task<bool> UpdateAsync(Student student, CancellationToken ct) { db.Students.Update(student); await db.SaveChangesAsync(ct); return true; }
    public async Task<bool> DeleteAsync(int id, CancellationToken ct) { var entity = await db.Students.FindAsync([id], ct); if (entity is null) return false; db.Students.Remove(entity); await db.SaveChangesAsync(ct); return true; }
}
