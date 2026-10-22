using EduSphere.AcademicsService.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;
namespace AcademicsService.Tests;
public class AcademicsDbContextTests
{
    [Fact]
    public async Task SeedData_ContainsDemoStudentAndCourse()
    {
        var options = new DbContextOptionsBuilder<AcademicsDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        await using var db = new AcademicsDbContext(options);
        await db.Database.EnsureCreatedAsync();
        Assert.Contains(await db.Students.ToListAsync(), x => x.StudentNumber == "STU-1001");
        Assert.Contains(await db.Courses.ToListAsync(), x => x.CourseCode == "CS101");
    }
}
