namespace StudyThink.Domain.Exceptions.Courses.CourseModuls;

public class CourseModulsNotFoundException:NotFoundException
{
    public CourseModulsNotFoundException()
    {
        TitleMessage = "Course Moduls Not Found!";
    }
}
