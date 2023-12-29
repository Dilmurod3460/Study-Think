namespace StudyThink.Domain.Entities.Courses;

public class Course:Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public long CategoryId { get; set; }
    public float Price { get; set; }
    public string? ImagePath { get; set; }
    public float TotalPrice { get; set; }
    public long Lessons { get; set; }
    public float Duration { get; set; }
    public string Language { get; set; }
    public float DiscountPrice { get; set; }
    public long CourseReqId { get; set; }

}
