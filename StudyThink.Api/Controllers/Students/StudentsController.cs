using Microsoft.AspNetCore.Mvc;
using StudyThink.DataAccess.Utils;
using StudyThink.Service.DTOs.Student;
using StudyThink.Service.Interfaces.Studentsk;

namespace StudyThink.Api.Controllers.Students;

[Route("api/[controller]/[action]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _service;
    private readonly int _maxPageSize = 30;

    public StudentsController(IStudentService service)
    {
        this._service = service;
    }

    [HttpGet]
    public async ValueTask<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromForm] StudentCreationDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync([FromForm] StudentUpdateDto dto)
        => Ok(await _service.UpdateAsync(dto));

    [HttpDelete]
    public async ValueTask<IActionResult> DeleteAsync(long id)
        => Ok(await _service.DeleteAsync(id));

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAll(new PaginationParams(page, _maxPageSize)));

    [HttpGet]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
        => Ok(await _service.GetByIdAsync(id));
}
