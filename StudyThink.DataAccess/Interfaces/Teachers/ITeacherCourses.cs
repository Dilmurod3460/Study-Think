using StudyThink.Domain.Entities.Courses;
using StudyThink.Domain.Entities.Teachers;

namespace StudyThink.DataAccess.Interfaces.Teachers;

public interface ITeacherCourses
{
    ValueTask<long> CountTeacherCoursesAsync(long teacherId);
    ValueTask<IEnumerable<Course>> GetTeacherCoursesAsync(long teacherId);
    ValueTask<Teacher> GetCourseTeacherAsync(long courseId);
    ValueTask<bool> DeleteTeacherFromCourseAsync(long teacherId, long courseId);
    ValueTask<bool> ChangeTeacherCourseAsync(long teacherId, long oldCourseId, long newCourseId);
    ValueTask<bool> AddTeacherToCourseAsync(long teacherId, long courseId);
}