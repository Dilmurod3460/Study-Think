using Microsoft.AspNetCore.Http;
using StudyThink.Domain.Entities;

namespace StudyThink.Service.DTOs.Callaborators;

public class CallaboratorsUpdateDto:BaseEntity
{
    public string Name { get; set; }
    public IFormFile? ImagePath { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
