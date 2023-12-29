using System.Reflection;

namespace StudyThink.Domain.Exceptions.Callaborator;

public class CallaboratorAlreadyExistsException:NotFoundException
{
    public CallaboratorAlreadyExistsException()
    {
        TitleMessage = "Callaborator already exist";
    }
}
