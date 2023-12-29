using Microsoft.AspNetCore.Mvc;
using StudyThink.DataAccess.Utils;
using StudyThink.Service.DTOs.Courses.CourseModel;
using StudyThink.Service.Interfaces.Courses;

namespace StudyThink.Api.Controllers.Courses;

[Route("api/[controller]/[action]")]
[ApiController]
public class CourseModulController : ControllerBase
{
    private readonly ICourseModulService _courseModulService;
    private readonly int _maxPageSize = 30;

    public CourseModulController(ICourseModulService courseModulService)
    {
        this._courseModulService = courseModulService;  
    }
    [HttpGet]
    public async ValueTask<IActionResult> CountAsync()
    {
        var result= await _courseModulService.CountAsync();
        return Ok(result);
    }
    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync(CourseModulCreationDto courseModulCreationDto)
    {
        var result=await _courseModulService.CreateAsync(courseModulCreationDto);
        return Ok(result);
    }
    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync(CourseModulUpdateDto courseModulUpdateDto)
    {
        var result =await _courseModulService.UpdateAsync(courseModulUpdateDto);
        return Ok(result);
    }
    [HttpDelete]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        var result =await _courseModulService.DeleteAsync(id);
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    {
        var result=await _courseModulService.GetByIdAsync(id);
        return Ok(result);
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync([FromQuery]int page = 1)
    {
        var result = await _courseModulService.GetAllAsync(new PaginationParams(page, _maxPageSize));
        return Ok(result);
    }
}
