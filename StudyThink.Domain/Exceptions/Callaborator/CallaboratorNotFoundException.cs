namespace StudyThink.Domain.Exceptions.Callaborator;

public class CallaboratorNotFoundException:NotFoundException
{
    public CallaboratorNotFoundException()
    {
        TitleMessage = "Callaborator not found";
    }
}
