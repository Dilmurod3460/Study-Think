using StudyThink.DataAccess.Interfaces.Videos;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Videos;
using StudyThink.Service.DTOs.Video;
using StudyThink.Service.Interfaces.Common;
using StudyThink.Service.Interfaces.Videos;

namespace StudyThink.Service.Services.Videos;

public class VideoService : IVideoService
{
    private readonly IVideoRepository _repository;
    private readonly IFileService _fileService;

    public VideoService(IVideoRepository repository,
        IFileService fileService)
    {
        this._repository = repository;
        this._fileService = fileService;
    }

    public ValueTask<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> CreateAsync(VideoCreationDto model)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<Video>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Video> GetByIdAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<Video>> GetVideoByModuleIdAsync(int modulId)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateAsync(long videoId, VideoUpdateDto model)
    {
        throw new NotImplementedException();
    }
}
