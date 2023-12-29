using AutoMapper;
using Microsoft.AspNetCore.Http;
using StudyThink.DataAccess.Interfaces.Teachers;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Teachers;
using StudyThink.Domain.Exceptions.Files;
using StudyThink.Domain.Exceptions.Teachers;
using StudyThink.Service.Common.Hasher;
using StudyThink.Service.Common.Helpers;
using StudyThink.Service.DTOs.Teachers;
using StudyThink.Service.Interfaces.Common;
using StudyThink.Service.Interfaces.Teachers;

namespace StudyThink.Service.Services.Teachers
{
    public class TeacherService : ITeacherService
    {
        private ITeacherRepository _teacherRepository;
        private IFileService _fileService;
        private IMapper _mapper;
        public TeacherService(ITeacherRepository teacherRepository, IFileService fileService, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _fileService = fileService;
            _mapper = mapper;
        }

        // Done
        public async ValueTask<long> CountAsync()
        {
            long count = await _teacherRepository.CountAsync();

            if (count == 0)
                throw new TeacherNotFoundException();
            return count;
        }

        // Done
        public async ValueTask<bool> CreateAsync(TeacherCreationDto model)
        {
            Teacher teacher = _mapper.Map<Teacher>(model);

            if (model.ImagePath == null)
            {
                throw new ImageNotFoundException();
            }
            else
            {
                teacher.ImagePath = await _fileService.UploadImageAsync(model.ImagePath);
                teacher.Password = Hash512.GenerateHash512(model.Password);

                bool dbResult = await _teacherRepository.CreateAsync(teacher);

                if (dbResult)
                    return true;
                throw new TeacherAlreadyExistsException();
            }

        }

        public async ValueTask<bool> DeleteAsync(long Id)
        {
            Teacher teacher = await _teacherRepository.GetByIdAsync(Id);

            if (teacher == null)
            {
                throw new TeacherNotFoundException();
            }
            else
            {
                bool image = await _fileService.DeleteImageAsync(teacher.ImagePath);

                if (image == false) throw new ImageNotFoundException();

                bool res = await _teacherRepository.DeleteAsync(Id);

                return res;
            }
        }

        public async ValueTask<bool> DeleteRangeAsync(List<long> teacherIds)
        {
            foreach (var i in teacherIds)
            {
                Teacher teacher = await _teacherRepository.GetByIdAsync(i);

                if (teacher != null)
                {
                    await _teacherRepository.DeleteAsync(i);
                    await _fileService.DeleteImageAsync(teacher.ImagePath);
                }
            }

            return true;
        }

        // Done
        public async ValueTask<IEnumerable<Teacher>> GetAllAsync(PaginationParams @params)
        {
            IEnumerable<Teacher> teachers = await _teacherRepository.GetAllAsync(@params);

            if (teachers == null)
            {
                throw new TeacherNotFoundException();
            }
            else
            {
                return teachers;
            }
        }

        public async ValueTask<Teacher> GetByEmailAsync(string email)
        {
            Teacher teacher = await _teacherRepository.GetByEmailAsync(email);

            if (teacher == null)
            {
                throw new TeacherNotFoundException();
            }
            else
            {
                return teacher;
            }
        }

        // Done
        public async ValueTask<Teacher> GetByIdAsync(long Id)
        {
            Teacher teacher = await _teacherRepository.GetByIdAsync(Id);

            if (string.IsNullOrEmpty(teacher.FirstName))
            {
                throw new TeacherNotFoundException();
            }
            return teacher;
        }

        // Done
        public async ValueTask<bool> UpdateAsync(TeacherUpdateDto model)
        {
            var teacher = await _teacherRepository.GetByIdAsync(model.Id);
            if (teacher is null)
                throw new TeacherNotFoundException();

            var teacherEmail = await _teacherRepository.GetByEmailAsync(model.Email);
            if (teacherEmail is not null)
                throw new TeacherAlreadyExistsException();

            string newImagePath = teacher.ImagePath;
            if (model.ImagePath is not null)
            {
                // Delete old image
                var deleteResult = await _fileService.DeleteImageAsync(teacher.ImagePath);
                if (!deleteResult)
                    throw new ImageNotFoundException();

                // Upload new image
                newImagePath = await _fileService.UploadImageAsync(model.ImagePath);
            }
            // else teacher old image have to save

            _mapper.Map(model, teacher);

            teacher.ImagePath = newImagePath;
            teacher.UpdatedAt = TimeHelper.GetDateTime();

            var result = await _teacherRepository.UpdateAsync(teacher);

            return result;

        }

        public ValueTask<bool> UpdateImageAsync(long teacherId, IFormFile teacherImage)
        {
            throw new NotImplementedException();
        }
    }
}
