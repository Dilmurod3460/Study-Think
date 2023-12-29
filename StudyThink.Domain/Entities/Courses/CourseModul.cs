namespace StudyThink.Domain.Entities.Courses;

public class CourseModul : Auditable
{
    public string Name { get; set; } = string.Empty;

    public long CourseId { get; set; }

}
