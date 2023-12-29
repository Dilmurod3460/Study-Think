using AutoMapper;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Courses;
using StudyThink.Domain.Exceptions.Courses.CourseRequirements;
using StudyThink.Service.Common.Helpers;
using StudyThink.Service.DTOs.Courses.CourseRequirment;
using StudyThink.Service.Interfaces.Common;
using StudyThink.Service.Interfaces.Courses;

namespace StudyThink.Service.Services.Courses;

public class CourseReqService : ICourseReqService
{
    private readonly ICourseReqRepository _repository;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public CourseReqService(ICourseReqRepository reqRepository,
        IFileService fileService, IMapper mapper)
    {
        this._repository = reqRepository;
        this._fileService = fileService;
        this._mapper = mapper;
    }

    public async ValueTask<long> CountAsync()
        => await _repository.CountAsync();

    public async ValueTask<bool> CreateAsync(CourseReqCretionDto model)
    {
        var courseReq = _mapper.Map<CourseRequirment>(model);

        courseReq.CreatedAt = TimeHelper.GetDateTime();
        courseReq.UpdatedAt = TimeHelper.GetDateTime();

        var result = await _repository.CreateAsync(courseReq);
        return result;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var courseReq = await _repository.GetByIdAsync(id);
        if (courseReq is null) throw new CourseRequirementsNotFoundException();

        var result = await _repository.DeleteAsync(id);
        return result;
    }

    public async ValueTask<bool> DeleteRangeAsync(List<long> CourseReqIds)
    {
        foreach (var i in CourseReqIds)
        {
            CourseRequirment coursereq = await _repository.GetByIdAsync(i);

            if (coursereq != null)
            {
                await _repository.DeleteAsync(i);
            }
        }

        return true;
    }

    public async ValueTask<IEnumerable<CourseRequirment>> GetAllAsync(PaginationParams @params)
    {
        return await _repository.GetAllAsync(@params);
    }

    public async ValueTask<CourseRequirment> GetByIdAsync(long id)
    {
        var courseReq = await _repository.GetByIdAsync(id);
        if (courseReq is null) throw new CourseRequirementsNotFoundException();

        return courseReq;
    }

    public async ValueTask<bool> UpdateAsync(CourseReqUpdateDto model)
    {
        var courseReqExists = await _repository.GetByIdAsync(model.Id);
        if (courseReqExists is null) throw new CourseRequirementsNotFoundException();

        var courseReq = _mapper.Map<CourseRequirment>(model);

        courseReq.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(courseReq);

        return dbResult;
    }
}
