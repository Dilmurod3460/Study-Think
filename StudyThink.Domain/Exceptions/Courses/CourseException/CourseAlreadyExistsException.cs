namespace StudyThink.Domain.Exceptions.Courses.CourseException;

public class CourseAlreadyExistsException:NotFoundException
{
    public CourseAlreadyExistsException()
    {
        TitleMessage = "Course already exist!";
    }
}
