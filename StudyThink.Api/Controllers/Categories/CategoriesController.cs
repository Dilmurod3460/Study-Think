using Microsoft.AspNetCore.Mvc;
using StudyThink.DataAccess.Utils;
using StudyThink.Service.DTOs.Category;
using StudyThink.Service.Interfaces.Categories;

namespace StudyThink.Api.Controllers.Categories;

[Route("api/[controller]/[action]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;
    private readonly int _maxPageSize = 30;

    public CategoriesController(ICategoryService service)
    {
        this._service = service;
    }

    [HttpGet]
    public async ValueTask<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromForm] CategoryCreationDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync([FromForm] CategoryUpdateDto dto)
        => Ok(await _service.UpdateAsync(dto));

    [HttpDelete]
    public async ValueTask<IActionResult> DeleteAsync(long id)
        => Ok(await _service.DeleteAsync(id));

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, _maxPageSize)));

    [HttpGet]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
        => Ok(await _service.GetByIdAsync(id));
}
