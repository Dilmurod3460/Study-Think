using StudyThink.DataAccess.Common;
using StudyThink.Domain.Entities.Payments;

namespace StudyThink.DataAccess.Interfaces.Payments;

public interface IPaymentRepository: IRepository<Payment>, IGetAll<Payment>
{

}
