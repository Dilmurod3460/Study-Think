using StudyThink.DataAccess.Utils;

namespace StudyThink.DataAccess.Common;

public interface ISearchable<T>
{
    public ValueTask<(long ItemsCount, IEnumerable<T>)> SearchAsync(string search,
        PaginationParams @params);
}
