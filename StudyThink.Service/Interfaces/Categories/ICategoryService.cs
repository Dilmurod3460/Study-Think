using Microsoft.AspNetCore.Http;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Categories;
using StudyThink.Service.DTOs.Category;

namespace StudyThink.Service.Interfaces.Categories;

public interface ICategoryService
{
    ValueTask<bool> CreateAsync(CategoryCreationDto model);
    ValueTask<Category> GetByIdAsync(long Id);
    ValueTask<IEnumerable<Category>> GetAllAsync(PaginationParams @params);
    ValueTask<long> CountAsync();
    ValueTask<bool> UpdateAsync(CategoryUpdateDto model);
    ValueTask<bool> DeleteAsync(long Id);
    ValueTask<bool> DeleteRangeAsync(List<long> categoryIds);
}
