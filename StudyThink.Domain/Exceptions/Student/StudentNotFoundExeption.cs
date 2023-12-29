namespace StudyThink.Domain.Exceptions.Student;

public class StudentNotFoundExeption:NotFoundException
{
    public StudentNotFoundExeption()
    {
        TitleMessage = "Student not found";
    }
}
