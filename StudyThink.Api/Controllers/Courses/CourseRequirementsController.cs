using Microsoft.AspNetCore.Mvc;
using StudyThink.DataAccess.Utils;
using StudyThink.Service.DTOs.Courses.CourseRequirment;
using StudyThink.Service.Interfaces.Courses;

namespace StudyThink.Api.Controllers.Courses;

[Route("api/[controller]/[action]")]
[ApiController]
public class CourseRequirementsController : ControllerBase
{
    private readonly ICourseReqService _service;
    private readonly int _maxPageSize = 30;

    public CourseRequirementsController(ICourseReqService service)
    {
        this._service = service;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, _maxPageSize)));

    [HttpGet]
    public async ValueTask<IActionResult> GetByIdAsync(int id)
        => Ok(await _service.GetByIdAsync(id));

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromForm] CourseReqCretionDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpPost]
    public async ValueTask<IActionResult> Updateasync([FromForm] CourseReqUpdateDto dto)
        => Ok(await _service.UpdateAsync(dto));

    [HttpGet]
    public async ValueTask<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpDelete]
    public async ValueTask<IActionResult> DeleteAsync(long courseReqId)
        => Ok(await _service.DeleteAsync(courseReqId));
}
