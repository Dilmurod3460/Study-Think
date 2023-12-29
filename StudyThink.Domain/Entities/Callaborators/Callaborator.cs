namespace StudyThink.Domain.Entities.Callaborators;

public class Callaborator : BaseEntity
{
    public string Name { get; set; }
    public string? ImagePath { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

}
