using StudyThink.Domain.Entities;

namespace StudyThink.Service.DTOs.Admin;

public class AdminUpdateDto:BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
