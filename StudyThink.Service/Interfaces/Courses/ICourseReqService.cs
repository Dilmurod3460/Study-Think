using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Courses;
using StudyThink.Service.DTOs.Courses.CourseRequirment;

namespace StudyThink.Service.Interfaces.Courses;

public interface ICourseReqService
{
    ValueTask<bool> CreateAsync(CourseReqCretionDto model);
    ValueTask<bool> UpdateAsync(CourseReqUpdateDto model);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<CourseRequirment> GetByIdAsync(long id);
    ValueTask<IEnumerable<CourseRequirment>> GetAllAsync(PaginationParams @params);
    ValueTask<long> CountAsync();
    ValueTask<bool> DeleteRangeAsync(List<long> CourseReqIds);


}
