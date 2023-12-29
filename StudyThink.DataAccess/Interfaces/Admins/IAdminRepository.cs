using StudyThink.DataAccess.Common;
using StudyThink.Domain.Entities.Admins;

namespace StudyThink.DataAccess.Interfaces.Admins;

public interface IAdminRepository : IRepository<Admin>,
    IGetAll<Admin>, ISearchable<Admin>
{
    ValueTask<Admin> GetByEmailAsync(string email);

    ValueTask<IEnumerable<Admin>> GetByPhoneNumberAsync(string phoneNumber);
}
