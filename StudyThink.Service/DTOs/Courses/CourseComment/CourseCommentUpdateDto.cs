namespace StudyThink.Service.DTOs.Courses.CourseComment;

public class CourseCommentUpdateDto
{
    public int Id { get; set; }
    public string Comment { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public int AdminId { get; set; }
}
