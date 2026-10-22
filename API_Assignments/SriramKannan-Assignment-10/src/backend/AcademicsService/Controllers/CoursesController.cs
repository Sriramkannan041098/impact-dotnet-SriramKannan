using EduSphere.AcademicsService.DTOs;
using EduSphere.AcademicsService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace EduSphere.AcademicsService.Controllers;
[ApiController, Route("academics/courses"), Authorize]
public sealed class CoursesController(ICourseService service) : ControllerBase
{
    [HttpGet, Authorize(Roles = "Teacher,Student")]
    public async Task<IActionResult> GetAll(CancellationToken ct) { try { return Ok(await service.GetAllAsync(ct)); } catch { return StatusCode(500, new { message = "Unable to retrieve courses." }); } }
    [HttpGet("{id:int}"), Authorize(Roles = "Teacher,Student")]
    public async Task<IActionResult> GetById(int id, CancellationToken ct) { try { var x = await service.GetByIdAsync(id, ct); return x is null ? NotFound() : Ok(x); } catch { return StatusCode(500, new { message = "Unable to retrieve course." }); } }
    [HttpPost, Authorize(Roles = "Teacher")]
    public async Task<IActionResult> Create(CreateCourseRequest request, CancellationToken ct) { try { var x = await service.CreateAsync(request, ct); return CreatedAtAction(nameof(GetById), new { id = x.Id }, x); } catch (ArgumentException ex) { return BadRequest(new { message = ex.Message }); } catch { return StatusCode(500, new { message = "Unable to create course." }); } }
    [HttpPut("{id:int}"), Authorize(Roles = "Teacher")]
    public async Task<IActionResult> Update(int id, UpdateCourseRequest request, CancellationToken ct) { try { return await service.UpdateAsync(id, request, ct) ? NoContent() : NotFound(); } catch (ArgumentException ex) { return BadRequest(new { message = ex.Message }); } catch { return StatusCode(500, new { message = "Unable to update course." }); } }
    [HttpDelete("{id:int}"), Authorize(Roles = "Teacher")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct) { try { return await service.DeleteAsync(id, ct) ? NoContent() : NotFound(); } catch { return StatusCode(500, new { message = "Unable to delete course." }); } }
}
