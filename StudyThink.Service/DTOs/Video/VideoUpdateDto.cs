namespace StudyThink.Service.DTOs.Video
{
    public class VideoUpdateDto : VideoCreationDto
    {
        public long Id { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
