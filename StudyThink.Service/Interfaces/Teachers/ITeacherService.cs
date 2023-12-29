using Microsoft.AspNetCore.Http;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Teachers;
using StudyThink.Service.DTOs.Teachers;

namespace StudyThink.Service.Interfaces.Teachers
{
    public interface ITeacherService
    {
        // Append
        ValueTask<bool> CreateAsync(TeacherCreationDto model);
        // Get
        ValueTask<Teacher> GetByIdAsync(long Id);
        ValueTask<IEnumerable<Teacher>> GetAllAsync(PaginationParams @params);
        ValueTask<Teacher> GetByEmailAsync(string email);
        ValueTask<long> CountAsync();
        // Update
        ValueTask<bool> UpdateAsync(TeacherUpdateDto model);
        ValueTask<bool> UpdateImageAsync(long teacherId, IFormFile teacherImage);
        // Delete
        ValueTask<bool> DeleteAsync(long Id);
        ValueTask<bool> DeleteRangeAsync(List<long> teacherIds);
    }
}
