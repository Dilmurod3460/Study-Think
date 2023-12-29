using AutoMapper;
using StudyThink.DataAccess.Interfaces.Coloborators;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Callaborators;
using StudyThink.Domain.Exceptions.Callaborator;
using StudyThink.Domain.Exceptions.Files;
using StudyThink.Service.DTOs.Callaborators;
using StudyThink.Service.DTOs.CallaboratorsDTO;
using StudyThink.Service.Interfaces.Collobarators;
using StudyThink.Service.Interfaces.Common;

namespace StudyThink.Service.Services.Callaborators;

public class CallaboratorService : ICallaboratorsService
{
    private ICalloboratorRepository _calloboratorRepository;
    private IFileService _fileService;
    private IMapper _mapper;
    public CallaboratorService(ICalloboratorRepository callaboratorRepository, IFileService fileService, IMapper mapper)
    {
        _calloboratorRepository = callaboratorRepository;
        _fileService = fileService;
        _mapper = mapper;
    }
    public async ValueTask<long> CountAsync()
    {
        long count = await _calloboratorRepository.CountAsync();

        if (count == 0)
            throw new CallaboratorNotFoundException();
        return count;
    }

    public async ValueTask<bool> CreateAsync(CallaboratorsCreationDto model)
    {
        Callaborator callaborator = _mapper.Map<Callaborator>(model);

        if (model.ImagePath == null)
        {
            throw new ImageNotFoundException();
        }
        else
        {
            callaborator.ImagePath = await _fileService.UploadImageAsync(model.ImagePath);

            bool dbResult = await _calloboratorRepository.CreateAsync(callaborator);

            if (dbResult)

                return true;
            throw new CallaboratorNotFoundException();
        }
    }

    public async ValueTask<bool> DeleteAsync(long Id)
    {
        Callaborator callaborator = await _calloboratorRepository.GetByIdAsync(Id);

        if (callaborator == null)
        {
            throw new CallaboratorNotFoundException();
        }
        else
        {
            bool image = await _fileService.DeleteImageAsync(callaborator.ImagePath);

            if (image == false) throw new ImageNotFoundException();

            bool res = await _calloboratorRepository.DeleteAsync(Id);

            return res;
        }
    }

    public async ValueTask<bool> DeleteRangeAsync(List<long> callaboratorIds)
    {
        foreach (var i in callaboratorIds)
        {
            Callaborator callaborator = await _calloboratorRepository.GetByIdAsync(i);

            if (callaborator != null)
            {
                await _calloboratorRepository.DeleteAsync(i);
                await _fileService.DeleteImageAsync(callaborator.ImagePath);
            }
        }

        return true;
    }

    public async ValueTask<IEnumerable<Callaborator>> GetAll(PaginationParams @params)
    {

        IEnumerable<Callaborator> callaborators = await _calloboratorRepository.GetAllAsync(@params);

        if (callaborators == null)
        {
            throw new CallaboratorNotFoundException();
        }
        else
        {
            return callaborators;
        }
    }

    public async ValueTask<Callaborator> GetByIdAsync(long Id)
    {
        Callaborator callaborator = await _calloboratorRepository.GetByIdAsync(Id);

        if (callaborator == null)
        {
            throw new CallaboratorNotFoundException();
        }
        return callaborator;
    }

    public async ValueTask<bool> UpdateAsync(CallaboratorsUpdateDto model)
    {
        Callaborator callaborator = _mapper.Map<Callaborator>(model);
        var result = await _calloboratorRepository.UpdateAsync(callaborator);

        return result;
    }
}
