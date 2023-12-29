using StudyThink.Domain.Entities.Courses;

namespace StudyThink.Service.Interfaces.Teachers
{
    internal interface ITeacherCoursesService
    {
        // Append
        ValueTask<bool> AddTeacherToCourseAsync(long teacherId, long courseId);
        // Get
        ValueTask<IEnumerable<Course>> GetTeacherCoursesAsync(long teacherId);
        ValueTask<Course> GetCourseTeacherAsync(long courseId);
        ValueTask<long> CountTeacherCoursesAsync(long teacherId);
        // Delete
        ValueTask<bool> DeleteTeacherFromCourseAsync(long teacherId, long courseId);
        // Update
        ValueTask<bool> ChangeTeacherCourseAsync(long teacherId, long oldCourseId, long newCourseId);
    }
}