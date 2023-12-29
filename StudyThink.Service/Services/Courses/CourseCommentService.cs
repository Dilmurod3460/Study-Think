using AutoMapper;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Course;
using StudyThink.Domain.Exceptions.Courses.CourseComments;
using StudyThink.Service.Common.Helpers;
using StudyThink.Service.DTOs.Courses.CourseComment;
using StudyThink.Service.Interfaces.Common;
using StudyThink.Service.Interfaces.Courses;

namespace StudyThink.Service.Services.Courses;

public class CourseCommentService : ICourseCommentService
{
    private readonly ICourseCommentRepository _repository;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public CourseCommentService(ICourseCommentRepository repository,
        IFileService fileService, IMapper mapper)
    {
        this._repository = repository;
        this._fileService = fileService;
        this._mapper = mapper;
    }

    public async ValueTask<long> CountAsync()
        => await _repository.CountAsync();



    public async ValueTask<bool> CreateAsync(CourseCommentCreationDto model)
    {
        var courseComment = _mapper.Map<CourseComment>(model);

        courseComment.CreatedAt = TimeHelper.GetDateTime();
        courseComment.UpdatedAt = TimeHelper.GetDateTime();

        var result = await _repository.CreateAsync(courseComment);
        return result;

    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existCourseComment = await _repository.GetByIdAsync(id);
        if (existCourseComment is null)
        {
            throw new CourseCommentsAlreadyExistsException();
        }
        var result = await _repository.DeleteAsync(id);
        return result;
    }

    public ValueTask<bool> DeleteRangeAsync(List<long> CourseCommentIds)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<IEnumerable<CourseComment>> GetAllAsync(PaginationParams @params)
    {
        var result = await _repository.GetAllAsync(@params);
        if (result is null)
        {
            throw new CourseCommentsNotFoundException();
        }
        return result;
    }

    public async ValueTask<CourseComment> GetByIdAsync(long id)
    {
        var result = await _repository.GetByIdAsync(id);
        if (result is null)
        {
            throw new CourseCommentsNotFoundException();
        }
        return result;
    }

    public async ValueTask<bool> UpdateAsync(CourseCommentUpdateDto model)
    {
        var existCpurseComment = await _repository.GetByIdAsync(model.Id);
        if (existCpurseComment is null)
        {
            throw new CourseCommentsNotFoundException();
        }
        CourseComment courseComment = _mapper.Map<CourseComment>(existCpurseComment);
        courseComment.UpdatedAt = TimeHelper.GetDateTime();
        var result = await _repository.UpdateAsync(courseComment);
        return result;
    }
}
