using EduSphere.AcademicsService.Data;
using EduSphere.AcademicsService.Models;
using Microsoft.EntityFrameworkCore;
namespace EduSphere.AcademicsService.Repositories;
public sealed class TeacherRepository(AcademicsDbContext db) : ITeacherRepository
{
    public Task<List<Teacher>> GetAllAsync(CancellationToken ct) => db.Teachers.AsNoTracking().OrderBy(x => x.Id).ToListAsync(ct);
    public Task<Teacher?> GetByIdAsync(int id, CancellationToken ct) => db.Teachers.FirstOrDefaultAsync(x => x.Id == id, ct);
    public async Task<Teacher> AddAsync(Teacher entity, CancellationToken ct) { db.Teachers.Add(entity); await db.SaveChangesAsync(ct); return entity; }
    public async Task SaveAsync(Teacher entity, CancellationToken ct) { db.Teachers.Update(entity); await db.SaveChangesAsync(ct); }
    public async Task<bool> DeleteAsync(int id, CancellationToken ct) { var entity = await db.Teachers.FindAsync([id], ct); if (entity is null) return false; db.Teachers.Remove(entity); await db.SaveChangesAsync(ct); return true; }
}
