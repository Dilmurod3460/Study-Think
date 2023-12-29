namespace StudyThink.Domain.Exceptions.Courses.CourseModuls;

public class CourseModulsAlreadyExistsException:NotFoundException
{
    public CourseModulsAlreadyExistsException()
    {
        TitleMessage = "Course Moduls allready exist!";
    }
}
