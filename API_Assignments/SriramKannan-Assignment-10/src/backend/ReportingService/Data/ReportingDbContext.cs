using Microsoft.EntityFrameworkCore;
using EduSphere.ReportingService.Models;
namespace EduSphere.ReportingService.Data;

// Replace this hand-written scaffold placeholder with generated EF DB First output.
// Run the Scaffold-DbContext command in database/README.md against ReportingDb.
public sealed class ReportingDbContext(DbContextOptions<ReportingDbContext> options) : DbContext(options)
{
    public DbSet<EnrollmentSummary> EnrollmentSummaries => Set<EnrollmentSummary>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EnrollmentSummary>(e => {
            e.ToTable("EnrollmentSummary", "dbo");
            e.HasKey(x => x.Id);
        });
    }
}
