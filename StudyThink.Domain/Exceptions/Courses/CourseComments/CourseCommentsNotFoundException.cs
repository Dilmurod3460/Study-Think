namespace StudyThink.Domain.Exceptions.Courses.CourseComments;

public class CourseCommentsNotFoundException:NotFoundException
{
    public CourseCommentsNotFoundException()
    {
        TitleMessage = "Course Comments not found!";
    }
}
