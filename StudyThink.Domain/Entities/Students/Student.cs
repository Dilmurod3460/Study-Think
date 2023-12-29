using StudyThink.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace StudyThink.Domain.Entities.Students;

public class Student : Human
{
    public string Username { get; set; } = string.Empty;

    [Required]
    public Gender Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string ImagePath { get; set; } = string.Empty;

    public DateTime DeletedAt { get; set; }
}
