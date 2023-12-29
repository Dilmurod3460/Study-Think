using Microsoft.AspNetCore.Http;
using StudyThink.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace StudyThink.Service.DTOs.Teachers;

public class TeacherCreationDto
{
    public TeacherLevel Level { get; set; }

    public string Description { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }

    public IFormFile ImagePath { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;
}
