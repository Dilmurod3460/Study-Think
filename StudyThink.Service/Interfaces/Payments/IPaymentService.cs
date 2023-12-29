using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Payments;
using StudyThink.Service.DTOs.Payment;

namespace StudyThink.Service.Interfaces.Payments;

public interface IPaymentService
{
    ValueTask<bool> CreateAsync(PaymentCreationDto model);
    ValueTask<Payment> GetByIdAsync(long Id);
    ValueTask<IEnumerable<Payment>> GetAllAsync(PaginationParams @params);
    ValueTask<long> CountAsync();
    ValueTask<bool> UpdateAsync(PaymentUpdateDto model);
    ValueTask<bool> DeleteAsync(long Id);
    ValueTask<bool> DeleteRangeAsync(List<long> paymentIds);
}
