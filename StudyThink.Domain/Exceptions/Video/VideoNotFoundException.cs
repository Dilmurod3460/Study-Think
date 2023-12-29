namespace StudyThink.Domain.Exceptions.Video
{
    public class VideoNotFoundException : NotFoundException
    {
        public VideoNotFoundException()
        {
            TitleMessage = "Video Not Found!";
        }
    }
}
