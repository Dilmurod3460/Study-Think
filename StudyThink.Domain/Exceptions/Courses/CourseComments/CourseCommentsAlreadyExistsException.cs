namespace StudyThink.Domain.Exceptions.Courses.CourseComments;

public class CourseCommentsAlreadyExistsException:NotFoundException
{
    public CourseCommentsAlreadyExistsException()
    {
        TitleMessage = "Course Comments already exist!";
    }
}
