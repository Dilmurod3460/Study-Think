using Microsoft.AspNetCore.Http;
using StudyThink.Domain.Entities;
using StudyThink.Domain.Enums;

namespace StudyThink.Service.DTOs.Student;

public class StudentUpdateDto:BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string UserName { get; set; }

    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Gender Gender { get; set; }
    public IFormFile? ImagePath { get; set; }
}
