using EduSphere.AcademicsService.DTOs;
using EduSphere.AcademicsService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduSphere.AcademicsService.Controllers;

[ApiController]
[Route("academics/students")]
[Authorize]
public sealed class StudentsController(IStudentService service) : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = "Teacher,Student")]
    public async Task<IActionResult> GetAll(CancellationToken ct) {
        try { return Ok(await service.GetAllAsync(ct)); }
        catch (Exception) { return StatusCode(500, new { message = "Unable to retrieve students." }); }
    }

    [HttpGet("{id:int}")]
    [Authorize(Roles = "Teacher,Student")]
    public async Task<IActionResult> GetById(int id, CancellationToken ct) {
        try { var result = await service.GetByIdAsync(id, ct); return result is null ? NotFound() : Ok(result); }
        catch (Exception) { return StatusCode(500, new { message = "Unable to retrieve student." }); }
    }

    [HttpPost]
    [Authorize(Roles = "Teacher")]
    public async Task<IActionResult> Create(CreateStudentRequest request, CancellationToken ct) {
        try { var created = await service.CreateAsync(request, ct); return CreatedAtAction(nameof(GetById), new { id = created.Id }, created); }
        catch (ArgumentException ex) { return BadRequest(new { message = ex.Message }); }
        catch (Exception) { return StatusCode(500, new { message = "Unable to create student." }); }
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Teacher")]
    public async Task<IActionResult> Update(int id, UpdateStudentRequest request, CancellationToken ct) {
        try { return await service.UpdateAsync(id, request, ct) ? NoContent() : NotFound(); }
        catch (Exception) { return StatusCode(500, new { message = "Unable to update student." }); }
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Teacher")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct) {
        try { return await service.DeleteAsync(id, ct) ? NoContent() : NotFound(); }
        catch (Exception) { return StatusCode(500, new { message = "Unable to delete student." }); }
    }
}
