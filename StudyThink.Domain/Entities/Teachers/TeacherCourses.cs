namespace StudyThink.Domain.Entities.Teachers;

public class TeacherCourses : BaseEntity
{
    public long CourseId { get; set; }

    public long TeacherId { get; set; }
}
