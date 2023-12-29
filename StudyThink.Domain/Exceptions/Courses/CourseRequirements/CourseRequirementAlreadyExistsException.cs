namespace StudyThink.Domain.Exceptions.Courses.CourseRequirements;

public class CourseRequirementAlreadyExistsException : NotFoundException
{
    public CourseRequirementAlreadyExistsException()
    {
        TitleMessage = "Course requirement already exists!";
    }
}
