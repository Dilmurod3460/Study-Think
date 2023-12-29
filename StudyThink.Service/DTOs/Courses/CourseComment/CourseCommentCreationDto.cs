namespace StudyThink.Service.DTOs.Courses.CourseComment;

public class CourseCommentCreationDto
{
    public string Comment { get; set; }
    public long StudentId { get; set; }
    public long CourseId { get; set; }
    public long AdminId { get; set; }
}
