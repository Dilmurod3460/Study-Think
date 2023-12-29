using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Admins;
using StudyThink.Service.DTOs.Admin;

namespace StudyThink.Service.Interfaces.Admins;

public interface IAdminService
{
    ValueTask<bool> CreateAsync(AdminCreationDto model);
    ValueTask<Admin> GetByIdAsync(long Id);
    ValueTask<IEnumerable<Admin>> GetAll(PaginationParams @params);
    ValueTask<long> CountAsync();
    ValueTask<bool> UpdateAsync(AdminUpdateDto model);
    ValueTask<bool> DeleteAsync(long Id);
    ValueTask<bool> DeleteRangeAsync(List<long> adminIds);
}
