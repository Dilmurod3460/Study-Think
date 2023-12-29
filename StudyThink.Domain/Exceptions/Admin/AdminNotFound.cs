using System.Net;

namespace StudyThink.Domain.Exceptions.AdminExseptions;

public class AdminNotFound : NotFoundException
{
    public AdminNotFound()
    {
        TitleMessage = "Admin not found";
    }
}
