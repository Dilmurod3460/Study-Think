using StudyThink.Domain.Enums;

namespace StudyThink.Domain.Entities.Admins;

public class Admin : Human
{
    public AdminRole Role { get; set; }

    public DateTime DeletedAt { get; set; }
}
