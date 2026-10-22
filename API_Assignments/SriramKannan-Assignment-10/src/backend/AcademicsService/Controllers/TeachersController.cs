using EduSphere.AcademicsService.DTOs;
using EduSphere.AcademicsService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace EduSphere.AcademicsService.Controllers;
[ApiController, Route("academics/teachers"), Authorize]
public sealed class TeachersController(ITeacherService service) : ControllerBase
{
    [HttpGet, Authorize(Roles = "Teacher,Student")]
    public async Task<IActionResult> GetAll(CancellationToken ct) { try { return Ok(await service.GetAllAsync(ct)); } catch { return StatusCode(500, new { message = "Unable to retrieve teachers." }); } }
    [HttpGet("{id:int}"), Authorize(Roles = "Teacher,Student")]
    public async Task<IActionResult> GetById(int id, CancellationToken ct) { try { var x = await service.GetByIdAsync(id, ct); return x is null ? NotFound() : Ok(x); } catch { return StatusCode(500, new { message = "Unable to retrieve teacher." }); } }
    [HttpPost, Authorize(Roles = "Teacher")]
    public async Task<IActionResult> Create(CreateTeacherRequest request, CancellationToken ct) { try { var x = await service.CreateAsync(request, ct); return CreatedAtAction(nameof(GetById), new { id = x.Id }, x); } catch (ArgumentException ex) { return BadRequest(new { message = ex.Message }); } catch { return StatusCode(500, new { message = "Unable to create teacher." }); } }
    [HttpPut("{id:int}"), Authorize(Roles = "Teacher")]
    public async Task<IActionResult> Update(int id, UpdateTeacherRequest request, CancellationToken ct) { try { return await service.UpdateAsync(id, request, ct) ? NoContent() : NotFound(); } catch (ArgumentException ex) { return BadRequest(new { message = ex.Message }); } catch { return StatusCode(500, new { message = "Unable to update teacher." }); } }
    [HttpDelete("{id:int}"), Authorize(Roles = "Teacher")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct) { try { return await service.DeleteAsync(id, ct) ? NoContent() : NotFound(); } catch { return StatusCode(500, new { message = "Unable to delete teacher." }); } }
}
