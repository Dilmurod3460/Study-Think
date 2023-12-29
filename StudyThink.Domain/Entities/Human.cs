using System.ComponentModel.DataAnnotations;

namespace StudyThink.Domain.Entities;

public class Human : Auditable
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;

}
