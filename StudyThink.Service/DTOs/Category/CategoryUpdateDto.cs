using StudyThink.Domain.Entities;

namespace StudyThink.Service.DTOs.Category;

public class CategoryUpdateDto:BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
}
