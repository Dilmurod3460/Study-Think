namespace StudyThink.Domain.Exceptions.Teachers;

public class TeacherNotFoundException : NotFoundException
{
    public TeacherNotFoundException()
    {
        TitleMessage = "Teacher not found!";
    }
}
