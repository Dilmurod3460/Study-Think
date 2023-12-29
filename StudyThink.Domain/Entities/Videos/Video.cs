namespace StudyThink.Domain.Entities.Videos
{
    public class Video : Auditable
    {
        public string Name { get; set; }
        public string? VideoPath { get; set; }
        public float Length { get; set; }
        public long CourseModulsId { get; set; }
        public long AdminId { get; set; }
    }
}
