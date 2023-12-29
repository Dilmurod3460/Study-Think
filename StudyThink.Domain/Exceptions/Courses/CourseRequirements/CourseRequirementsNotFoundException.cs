namespace StudyThink.Domain.Exceptions.Courses.CourseRequirements;

public class CourseRequirementsNotFoundException : NotFoundException
{
    public CourseRequirementsNotFoundException()
    {
        TitleMessage = "Course requirement Not found!";
    }
}
