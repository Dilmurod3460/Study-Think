using StudyThink.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace StudyThink.Domain.Entities.Teachers;

public class Teacher : Human
{
    public TeacherLevel Level { get; set; }

    public string Description { get; set; } = string.Empty;

    [Required]
    public Gender Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string ImagePath { get; set; } = string.Empty;

}