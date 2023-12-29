using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Payments;
using StudyThink.Service.DTOs.Payment;

namespace StudyThink.Service.Interfaces.Payments;

public interface IPaymentDetailsService
{
    ValueTask<bool> CreateAsync(PaymentDetailsCretionDto model);
    ValueTask<PaymentDetails> GetByIdAsync(long Id);
    ValueTask<IEnumerable<PaymentDetails>> GetAllAsync(PaginationParams @params);
    ValueTask<long> CountAsync();
    ValueTask<bool> UpdateAsync(PaymentDetailsUpdateDto model);
    ValueTask<bool> DeleteRangeAsync(List<long> paymenDetailsIds);
}
