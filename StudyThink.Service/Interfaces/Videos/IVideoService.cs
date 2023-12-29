using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Videos;
using StudyThink.Service.DTOs.Video;

namespace StudyThink.Service.Interfaces.Videos
{
    public interface IVideoService
    {
        // Create
        ValueTask<bool> CreateAsync(VideoCreationDto model);
        // Get
        ValueTask<long> CountAsync();
        ValueTask<IEnumerable<Video>> GetAllAsync(PaginationParams @params);
        ValueTask<IEnumerable<Video>> GetVideoByModuleIdAsync(int modulId);
        ValueTask<Video> GetByIdAsync(long Id);
        // Delete
        ValueTask<bool> DeleteAsync(long Id);
        // Update
        ValueTask<bool> UpdateAsync(long videoId, VideoUpdateDto model);
    }
}