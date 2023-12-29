namespace StudyThink.Domain.Exceptions.Courses.CourseException;

public class CourseNotFoundException:NotFoundException
{
    public CourseNotFoundException()
    {
        TitleMessage = "Course not found! ";
    }
}
