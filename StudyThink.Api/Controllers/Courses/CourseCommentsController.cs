using Microsoft.AspNetCore.Mvc;
using StudyThink.DataAccess.Utils;
using StudyThink.Service.DTOs.Courses.CourseComment;
using StudyThink.Service.Interfaces.Courses;

namespace StudyThink.Api.Controllers.Courses;

[Route("api/[controller]/[action]")]
[ApiController]
public class CourseCommentsController : ControllerBase
{
    private readonly ICourseCommentService _courseCommentService;
    private readonly int _maxPageSize = 30;

    public CourseCommentsController(ICourseCommentService courseCommentService)
    {
        _courseCommentService = courseCommentService;
    }

    [HttpGet]

    public async ValueTask<IActionResult> CountAsync()
    {
        var result = await  _courseCommentService.CountAsync();
        return Ok(result);
    }
    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromForm] CourseCommentCreationDto dto)
    {
        var result = await _courseCommentService.CreateAsync(dto);
        return Ok(result);
    }
    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync([FromForm] CourseCommentUpdateDto dto)
    {
        var result=await _courseCommentService.UpdateAsync(dto);
        return Ok(result);
    }
    [HttpDelete]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        var result =await _courseCommentService.DeleteAsync(id);
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    {
        var result=await _courseCommentService.GetByIdAsync(id);
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync([FromQuery] int page = 1)
    {
        var result = await _courseCommentService.GetAllAsync(new PaginationParams(page, _maxPageSize));
        return Ok(result);
       
    }
}
