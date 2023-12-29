using Microsoft.AspNetCore.Http;
using StudyThink.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace StudyThink.Service.DTOs.Student;

public class StudentCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }
    public string UserName { get; set; }

    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Gender Gender { get; set; }
    public IFormFile ImagePath { get; set; }
}
