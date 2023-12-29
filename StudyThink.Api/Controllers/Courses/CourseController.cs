using Microsoft.AspNetCore.Mvc;
using StudyThink.DataAccess.Utils;
using StudyThink.Service.DTOs.Courses.Course;
using StudyThink.Service.Interfaces.Courses;

namespace StudyThink.Api.Controllers.Courses;

[Route("api/[controller]/[action]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseService courseService;
    private readonly int _maxPageSize = 30;

    public CourseController(ICourseService courseService)
    {
        this.courseService = courseService;
    }

    [HttpGet]
    public async ValueTask<IActionResult> CountAsync()
    {
        var result = await courseService.CountAsync();
        return Ok(result);
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromForm] CourseCreationDto courseCreationDto)
    {
        var result = await courseService.CreateAsync(courseCreationDto);
        return Ok(result);
    }
    [HttpDelete]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        var result = await courseService.DeleteAsync(id);
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync([FromQuery] int page = 1)
    {
        var result = await courseService.GetAllAsync(new PaginationParams(page, _maxPageSize));
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    {
        var result = await courseService.GetByIdAsync(id);
        return Ok(result);
    }
    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync([FromForm] CourseUpdateDto courseUpdateDto)
    {
        var result = await courseService.UpdateAsync(courseUpdateDto);
        return Ok(result);
    }




}
