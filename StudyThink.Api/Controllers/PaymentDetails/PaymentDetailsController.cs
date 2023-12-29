using Microsoft.AspNetCore.Mvc;
using StudyThink.DataAccess.Utils;
using StudyThink.Service.DTOs.Payment;
using StudyThink.Service.Interfaces.Payments;

namespace StudyThink.Api.Controllers.PaymentDetails;
[Route("api/[controller]/[action]")]
[ApiController]
public class PaymentDetailsController : ControllerBase
{
    private readonly IPaymentDetailsService _paymentDetailsService;
    private readonly int _maxPageSize = 30;

    public PaymentDetailsController(IPaymentDetailsService paymentDetailsService)
    {
        this._paymentDetailsService = paymentDetailsService;
    }
    [HttpGet]
    public async ValueTask<IActionResult> CountAsync()
        => Ok(await _paymentDetailsService.CountAsync());
    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromForm] PaymentDetailsCretionDto dto)
        => Ok(await _paymentDetailsService.CreateAsync(dto));
    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync([FromForm] PaymentDetailsUpdateDto dto)
        => Ok(await _paymentDetailsService.UpdateAsync(dto));
    [HttpDelete]
    public async ValueTask<IActionResult> DeleteRangeAsync(List<long> paymentIds)
        => Ok(await _paymentDetailsService.DeleteRangeAsync(paymentIds));

    //[HttpGet]
    //public async ValueTask<IActionResult> GetAllAsync([FromQuery] int page = 1)
    //    => Ok(await _paymentDetailsService.GetAllAsync(new PaginationParams(page, _maxPageSize)));
    [HttpGet]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
        => Ok(await _paymentDetailsService.GetByIdAsync(id));


}
