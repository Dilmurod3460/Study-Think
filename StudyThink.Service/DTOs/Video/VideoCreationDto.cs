namespace StudyThink.Service.DTOs.Video
{
    public class VideoCreationDto
    {
        public string Name { get; set; }
        public string? VideoPath { get; set; }
        public float Length { get; set; }
        public long CourseModulsId { get; set; }
        public long AdminId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}