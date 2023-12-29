using Microsoft.AspNetCore.Http;

namespace StudyThink.Service.DTOs.Courses.Course;

public class CourseCreationDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public long CategoryId { get; set; }
    public float Price { get; set; }
    public IFormFile ImagePath { get; set; }
    public float TotalPrice { get; set; }
    public long Lessons { get; set; }
    public float Duration { get; set; }
    public string Language { get; set; }
    public float DiscountPrice { get; set; }
    public long CourseReqId { get; set; }

}
