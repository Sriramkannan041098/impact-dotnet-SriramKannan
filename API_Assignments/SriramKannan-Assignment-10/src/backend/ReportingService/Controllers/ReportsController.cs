using EduSphere.ReportingService.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduSphere.ReportingService.Controllers;
[ApiController]
[Route("reporting")]
[Authorize(Roles = "Teacher")]
public sealed class ReportsController(ReportingDbContext db) : ControllerBase
{
    [HttpGet("enrollment-summaries")]
    public async Task<IActionResult> EnrollmentSummaries(CancellationToken ct)
    {
        try {
            var rows = await db.EnrollmentSummaries.AsNoTracking().OrderByDescending(x => x.SnapshotUtc).ToListAsync(ct);
            return Ok(rows);
        }
        catch (Exception) { return StatusCode(500, new { message = "Unable to load reporting data." }); }
    }
}
