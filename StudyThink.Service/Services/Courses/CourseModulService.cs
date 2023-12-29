using AutoMapper;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Courses;
using StudyThink.Domain.Exceptions.Courses.CourseModuls;
using StudyThink.Service.Common.Helpers;
using StudyThink.Service.DTOs.Courses.CourseModel;
using StudyThink.Service.Interfaces.Common;
using StudyThink.Service.Interfaces.Courses;

namespace StudyThink.Service.Services.Courses;

public class CourseModulService : ICourseModulService
{
    private readonly ICourseModulRepository _repository;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public CourseModulService(ICourseModulRepository repository,
        IFileService fileService, IMapper mapper)
    {
        this._repository = repository;
        this._fileService = fileService;
        this._mapper = mapper;
    }

    public async ValueTask<long> CountAsync()
    {
        var result = await _repository.CountAsync();

        return result;
    }

    public async ValueTask<bool> CreateAsync(CourseModulCreationDto model)
    {
        var existCourseModul = await _repository.GetByNameAsync(model.Name);
        if (existCourseModul is null)
        {
            throw new CourseModulsNotFoundException();
        }
        CourseModul courseModul = _mapper.Map<CourseModul>(existCourseModul);

        courseModul.CreatedAt = courseModul.CreatedAt.Date.Add(new TimeSpan(11, 11, 11));
        courseModul.UpdatedAt = courseModul.UpdatedAt.Date.Add(new TimeSpan(11, 11, 11));
        var result = await _repository.CreateAsync(courseModul);
        return result;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existCourseModul = await _repository.GetByIdAsync(id);
        if (existCourseModul is null)
        {
            throw new CourseModulsNotFoundException();
        }
        var result = await _repository.DeleteAsync(id);
        return result;
    }

    public async ValueTask<bool> DeleteRangeAsync(List<long> CourseModulIds)
    {
        foreach (var i in CourseModulIds)
        {
            CourseModul courseModul = await _repository.GetByIdAsync(i);

            if (courseModul != null)
            {
                await _repository.DeleteAsync(i);
            }
        }

        return true;
    }

    public async ValueTask<IEnumerable<CourseModul>> GetAllAsync(PaginationParams @params)
    {
        var result = await _repository.GetAllAsync(@params);
        if (result is null)
        {
            throw new CourseModulsNotFoundException();
        }
        return result;

    }

    public async ValueTask<CourseModul> GetByIdAsync(long id)
    {
        var result = await _repository.GetByIdAsync(@id);
        if (result is null)
        {
            throw new CourseModulsNotFoundException();
        }
        return result;
    }

    public async ValueTask<bool> UpdateAsync(CourseModulUpdateDto model)
    {
        var existCourseModul = await _repository.GetByIdAsync(model.Id);
        if (existCourseModul is null)
            throw new CourseModulsNotFoundException();
        CourseModul courseModul = _mapper.Map<CourseModul>(existCourseModul);
        courseModul.UpdatedAt = TimeHelper.GetDateTime();
        var result = await _repository.UpdateAsync(courseModul);
        return result;
    }
}
