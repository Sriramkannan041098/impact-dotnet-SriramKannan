using EduSphere.AcademicsService.Data;
using EduSphere.AcademicsService.Models;
using Microsoft.EntityFrameworkCore;
namespace EduSphere.AcademicsService.Repositories;
public sealed class CourseRepository(AcademicsDbContext db) : ICourseRepository
{
    public Task<List<Course>> GetAllAsync(CancellationToken ct) => db.Courses.AsNoTracking().OrderBy(x => x.Id).ToListAsync(ct);
    public Task<Course?> GetByIdAsync(int id, CancellationToken ct) => db.Courses.FirstOrDefaultAsync(x => x.Id == id, ct);
    public async Task<Course> AddAsync(Course entity, CancellationToken ct) { db.Courses.Add(entity); await db.SaveChangesAsync(ct); return entity; }
    public async Task SaveAsync(Course entity, CancellationToken ct) { db.Courses.Update(entity); await db.SaveChangesAsync(ct); }
    public async Task<bool> DeleteAsync(int id, CancellationToken ct) { var entity = await db.Courses.FindAsync([id], ct); if (entity is null) return false; db.Courses.Remove(entity); await db.SaveChangesAsync(ct); return true; }
}
