using StudyThink.DataAccess.Utils;

namespace StudyThink.Service.Interfaces.Common;

public interface IPaginator
{
    public void Paginate(long itemsCount, PaginationParams @params);
}
