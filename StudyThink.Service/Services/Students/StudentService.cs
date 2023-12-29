using AutoMapper;
using Microsoft.AspNetCore.Http;
using StudyThink.DataAccess.Interfaces.Students;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Students;
using StudyThink.Domain.Exceptions.Files;
using StudyThink.Domain.Exceptions.Student;
using StudyThink.Service.Common.Hasher;
using StudyThink.Service.Common.Helpers;
using StudyThink.Service.DTOs.Student;
using StudyThink.Service.Interfaces.Common;
using StudyThink.Service.Interfaces.Studentsk;

namespace StudyThink.Service.Services.Students;

public class StudentService : IStudentService
{
    private IStudentRepository _studentRepository;
    private IFileService _fileService;
    private IMapper _mapper;

    public StudentService(IStudentRepository studentRepository, IFileService fileService, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _fileService = fileService;
        _mapper = mapper;
    }

    public async ValueTask<long> CountAsync()
        => await _studentRepository.CountAsync();

    public async ValueTask<bool> CreateAsync(StudentCreationDto model)
    {
        var exits = await _studentRepository.GetByEmailAsync(model.Email);

        if (exits is not null)
            throw new StudentAlreadyExistsException();

        string imagePath = await _fileService.UploadImageAsync(model.ImagePath);

        var student = _mapper.Map<Student>(model);

        student.DateOfBirth = student.DateOfBirth.Date.Add(new TimeSpan(00, 00, 00));
        student.DeletedAt = student.DateOfBirth.Date.Add(new TimeSpan(00, 00, 00));

        student.ImagePath = imagePath;
        student.Password = Hash512.GenerateHash512(student.Password);

        student.UpdatedAt = TimeHelper.GetDateTime();

        var result = await _studentRepository.CreateAsync(student);

        return result;
    }

    public async ValueTask<bool> DeleteAsync(long Id)
    {
        Student student = await _studentRepository.GetByIdAsync(Id);

        if (student == null)
        {
            throw new StudentNotFoundExeption();
        }
        else
        {
            bool image = await _fileService.DeleteImageAsync(student.ImagePath);

            if (image == false) throw new ImageNotFoundException();

            bool res = await _studentRepository.DeleteAsync(Id);

            return res;
        }
    }

    public async ValueTask<bool> DeleteRangeAsync(List<long> studentIds)
    {
        foreach (var i in studentIds)
        {
            Student student = await _studentRepository.GetByIdAsync(i);

            if (student != null)
            {
                await _studentRepository.DeleteAsync(i);
                await _fileService.DeleteImageAsync(student.ImagePath);
            }
        }

        return true;
    }

    public async ValueTask<IEnumerable<Student>> GetAll(PaginationParams @params)
    {
        IEnumerable<Student> students = await _studentRepository.GetAllAsync(@params);

        if (students == null)
        {
            throw new StudentNotFoundExeption();
        }
        else
        {
            return students;
        }
    }

    public async ValueTask<Student> GetByIdAsync(long Id)
    {
        Student student = await _studentRepository.GetByIdAsync(Id);

        if (student == null)
        {
            throw new StudentNotFoundExeption();
        }
        return student;
    }

    public async ValueTask<bool> UpdateAsync(StudentUpdateDto model)
    {
        var student = await _studentRepository.GetByIdAsync(model.Id);
        if (student is null)
            throw new StudentNotFoundExeption();

        var usernameResult = await _studentRepository.GetByUserNameAsync(model.UserName);
        if (usernameResult is not null)
            throw new StudentAlreadyExistsException();

        string newImagePath = student.ImagePath;

        if (model.ImagePath is not null)
        {
            // Delete old image 
            var deleteResult = await _fileService.DeleteImageAsync(student.ImagePath);
            if (!deleteResult)
                throw new ImageNotFoundException();

            // Upload new Image
            newImagePath = await _fileService.UploadImageAsync(model.ImagePath);
        }
        // else student old image have to save

        _mapper.Map(model, student);

        student.UpdatedAt = TimeHelper.GetDateTime();
        student.ImagePath = newImagePath;

        var result = await _studentRepository.UpdateAsync(student);

        return result;
    }

    public ValueTask<bool> UpdateImageAsync(long studentId, IFormFile imageStudent)
    {
        throw new NotImplementedException();
    }
}
