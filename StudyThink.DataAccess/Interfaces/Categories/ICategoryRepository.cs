using StudyThink.DataAccess.Common;
using StudyThink.Domain.Entities.Categories;

namespace StudyThink.DataAccess.Interfaces.Categories;

public interface ICategoryRepository : IRepository<Category>,
    IGetAll<Category>, ISearchable<Category>
{
    public Task<bool> UpdateImageAsync(long categoryId, string imagePath);
}
