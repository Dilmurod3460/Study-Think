using Microsoft.AspNetCore.Http;

namespace StudyThink.Service.DTOs.CallaboratorsDTO;

public class CallaboratorsCreationDto
{
    public string Name { get; set; }
    public IFormFile ImagePath { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
