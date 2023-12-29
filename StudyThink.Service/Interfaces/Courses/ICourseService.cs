using Microsoft.AspNetCore.Http;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Courses;
using StudyThink.Service.DTOs.Courses.Course;

namespace StudyThink.Service.Interfaces.Courses;

public interface ICourseService
{
    ValueTask<bool> CreateAsync(CourseCreationDto model);
    ValueTask<Course> GetByIdAsync(long Id);
    ValueTask<IEnumerable<Course>> GetAllAsync(PaginationParams @params);
    ValueTask<long> CountAsync();
    ValueTask<bool> UpdateAsync(CourseUpdateDto model);
    ValueTask<bool> DeleteAsync(long Id);
    ValueTask<bool> UpdateImageAsync(long courseId, IFormFile imageCourse);
    ValueTask<bool> DeleteRangeAsync(List<long> courseIds);

}
