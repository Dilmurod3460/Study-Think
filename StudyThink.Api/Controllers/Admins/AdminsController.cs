using Microsoft.AspNetCore.Mvc;
using StudyThink.DataAccess.Utils;
using StudyThink.Service.DTOs.Admin;
using StudyThink.Service.Interfaces.Admins;

namespace StudyThink.Api.Controllers.Admins;
[Route("api/[controller]/[action]")]
[ApiController]
public class AdminsController : ControllerBase
{
    private readonly IAdminService _service;
    private readonly int _maxPageSize = 30;

    public AdminsController(IAdminService service)
    {
        _service = service;
    }

    [HttpGet]
    public async ValueTask<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync(int page = 1)
        => Ok(await _service.GetAll(new PaginationParams(page, _maxPageSize)));

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync(AdminCreationDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync(AdminUpdateDto dto)
        => Ok(await _service.UpdateAsync(dto));

    [HttpDelete]
    public async ValueTask<IActionResult> DeleteAsync(long adminId)
        => Ok(await _service.DeleteAsync(adminId));

    [HttpGet]
    public async ValueTask<IActionResult> GetByIdAsync(long adminId)
        => Ok(await _service.GetByIdAsync(adminId));
}
