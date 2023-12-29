using AutoMapper;
using StudyThink.DataAccess.Interfaces.Categories;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Categories;
using StudyThink.Domain.Exceptions.CategoryExceptions;
using StudyThink.Service.DTOs.Category;
using StudyThink.Service.Interfaces.Categories;

namespace StudyThink.Service.Services.Categories;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository repository, IMapper mapper)
    {
        this._repository = repository;
        this._mapper = mapper;
    }

    public async ValueTask<long> CountAsync() => await _repository.CountAsync();

    public async ValueTask<bool> CreateAsync(CategoryCreationDto model)
    {
        Category category = _mapper.Map<Category>(model);

        return await _repository.CreateAsync(category);
    }

    public async ValueTask<bool> DeleteAsync(long Id)
    {
        if (Id <= 0)
            return false;

        return await _repository.DeleteAsync(Id);
    }

    public async ValueTask<bool> DeleteRangeAsync(List<long> categoryIds)
    {
        foreach (var i in categoryIds)
        {
            Category category = await _repository.GetByIdAsync(i);

            if (category != null)
            {
                await _repository.DeleteAsync(i);
            }
        }

        return true;
    }

    public async ValueTask<IEnumerable<Category>> GetAllAsync(PaginationParams @params)
    {
        var result = await _repository.GetAllAsync(@params);
        return result;
    }

    public async ValueTask<Category> GetByIdAsync(long Id)
    {
        var result = await _repository.GetByIdAsync(Id);

        if (result == null) throw new CategoryNotFound();

        return result;
    }

    public async ValueTask<bool> UpdateAsync(CategoryUpdateDto model)
    {
        var category = await _repository.GetByIdAsync(model.Id);
        if (category is null) throw new CategoryNotFound();

        category.Name = model.Name;
        category.Description = model.Description;

        //_mapper.Map(category, model);
        return await _repository.UpdateAsync(category);
    }
}
