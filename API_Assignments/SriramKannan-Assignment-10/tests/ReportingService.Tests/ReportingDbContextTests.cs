using EduSphere.ReportingService.Data;
using EduSphere.ReportingService.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;
namespace ReportingService.Tests;
public class ReportingDbContextTests
{
    [Fact]
    public async Task CanReadEnrollmentSummaryFromTestDatabase()
    {
        var options = new DbContextOptionsBuilder<ReportingDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        await using var db = new ReportingDbContext(options);
        db.EnrollmentSummaries.Add(new EnrollmentSummary { Id = 1, CourseCode = "CS101", CourseTitle = "Computing", TotalStudents = 3, ActiveEnrollments = 2, SnapshotUtc = DateTime.UtcNow });
        await db.SaveChangesAsync();
        Assert.Single(await db.EnrollmentSummaries.ToListAsync());
    }
}
