using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Callaborators;
using StudyThink.Service.DTOs.Callaborators;
using StudyThink.Service.DTOs.CallaboratorsDTO;

namespace StudyThink.Service.Interfaces.Collobarators;

public interface ICallaboratorsService
{
    ValueTask<bool> CreateAsync(CallaboratorsCreationDto model);
    ValueTask<Callaborator> GetByIdAsync(long Id);
    ValueTask<IEnumerable<Callaborator>> GetAll(PaginationParams @params);
    ValueTask<long> CountAsync();
    ValueTask<bool> UpdateAsync(CallaboratorsUpdateDto model);
    ValueTask<bool> DeleteAsync(long Id);
    ValueTask<bool> DeleteRangeAsync(List<long> callaboratorIds);
}
