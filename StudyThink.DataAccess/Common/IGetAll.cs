using StudyThink.DataAccess.Utils;

namespace StudyThink.DataAccess.Common;

public interface IGetAll<T>
{
    public ValueTask<IEnumerable<T>> GetAllAsync(PaginationParams @params);
}
