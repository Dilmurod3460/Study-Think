using AutoMapper;
using Microsoft.AspNetCore.Http;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Courses;
using StudyThink.Domain.Exceptions.Courses.CourseException;
using StudyThink.Service.Common.Helpers;
using StudyThink.Service.DTOs.Courses.Course;
using StudyThink.Service.Interfaces.Courses;

namespace StudyThink.Service.Services.Courses;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;
    public CourseService(ICourseRepository repo, IMapper mapper)
    {
        this._courseRepository = repo;
        this._mapper = mapper;
    }

    public async ValueTask<long> CountAsync() => await _courseRepository.CountAsync();

    public async ValueTask<bool> CreateAsync(CourseCreationDto model)
    {
        var existCourse = await _courseRepository.GetByNameAsync(model.Name);
        if (existCourse is not null)
        {
            throw new CourseAlreadyExistsException();
        }

        Course course = _mapper.Map<Course>(model);

        var result = await _courseRepository.CreateAsync(course);

        return result;

    }

    public async ValueTask<bool> DeleteAsync(long Id)
    {
        var existCourse = await _courseRepository.GetByIdAsync(Id);
        if (existCourse is null)
        {
            throw new CourseNotFoundException();
        }
        var result = await _courseRepository.DeleteAsync(Id);
        return result;
    }

    public async ValueTask<bool> DeleteRangeAsync(List<long> courseIds)
    {
        foreach (var i in courseIds)
        {
            Course course = await _courseRepository.GetByIdAsync(i);

            if (course != null)
            {
                await _courseRepository.DeleteAsync(i);
            }
        }

        return true;
    }

    public async ValueTask<IEnumerable<Course>> GetAllAsync(PaginationParams @params)
    {
        var result = await _courseRepository.GetAllAsync(@params);
        if (result is null)
        {
            throw new CourseNotFoundException();
        }
        return result;
    }

    public async ValueTask<Course> GetByIdAsync(long Id)
    {
        var result = await _courseRepository.GetByIdAsync(Id);
        if (result is null)
        {
            throw new CourseNotFoundException();
        }
        return result;
    }

    public async ValueTask<bool> UpdateAsync(CourseUpdateDto model)
    {
        var existCourse = await _courseRepository.GetByIdAsync(model.Id);
        if (existCourse is null)
        {
            throw new CourseNotFoundException();
        }
        Course course = _mapper.Map<Course>(model);
        course.UpdatedAt = TimeHelper.GetDateTime();
        var result = await _courseRepository.UpdateAsync(course);

        return result;
    }

    public ValueTask<bool> UpdateImageAsync(long courseId, IFormFile imageCourse)
    {
        throw new NotImplementedException();
    }
}
