using Microsoft.AspNetCore.Http;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Courses;
using StudyThink.Service.DTOs.Courses.CourseModel;

namespace StudyThink.Service.Interfaces.Courses;

public interface ICourseModulService
{
    ValueTask<bool> CreateAsync(CourseModulCreationDto model);
    ValueTask<bool> UpdateAsync(CourseModulUpdateDto model);
    ValueTask<IEnumerable<CourseModul>> GetAllAsync(PaginationParams @params);
    ValueTask<CourseModul> GetByIdAsync(long id);
    ValueTask<long> CountAsync();
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<bool> DeleteRangeAsync(List<long> CourseModulIds);
}
