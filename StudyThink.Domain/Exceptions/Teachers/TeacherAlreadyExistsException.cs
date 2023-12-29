namespace StudyThink.Domain.Exceptions.Teachers;

public class TeacherAlreadyExistsException : NotFoundException
{
    public TeacherAlreadyExistsException()
    {
        TitleMessage = "Teacher already exists!";
    }
}
