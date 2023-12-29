using StudyThink.DataAccess.Common;
using StudyThink.Domain.Entities.Videos;

namespace StudyThink.DataAccess.Interfaces.Videos;

public interface IVideoRepository : IRepository<Video> , IGetAll<Video>
{
    ValueTask<IEnumerable<Video>> GetVideoByModulIdAsync(long modulId);
}