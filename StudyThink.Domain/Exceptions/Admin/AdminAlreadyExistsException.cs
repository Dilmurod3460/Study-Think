namespace StudyThink.Domain.Exceptions.Admin;

public class AdminAlreadyExistsException : NotFoundException
{
    public AdminAlreadyExistsException()
    {
        TitleMessage = "Admin already exists!";
    }
}
