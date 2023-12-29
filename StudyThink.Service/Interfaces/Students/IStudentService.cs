using Microsoft.AspNetCore.Http;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Students;
using StudyThink.Service.DTOs.Student;

namespace StudyThink.Service.Interfaces.Studentsk
{
    public interface IStudentService
    {
        ValueTask<bool> CreateAsync(StudentCreationDto model);
        ValueTask<Student> GetByIdAsync(long Id);
        ValueTask<IEnumerable<Student>> GetAll(PaginationParams @params);
        ValueTask<long> CountAsync();
        ValueTask<bool> UpdateAsync(StudentUpdateDto model);
        ValueTask<bool> DeleteAsync(long Id);
        ValueTask<bool> UpdateImageAsync(long studentId, IFormFile imageStudent);
        ValueTask<bool> DeleteRangeAsync(List<long> studentIds);
    }
}
