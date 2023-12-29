using StudyThink.DataAccess.Common;
using StudyThink.Domain.Entities.Students;
using StudyThink.Domain.Entities.Teachers;

namespace StudyThink.DataAccess.Interfaces.Teachers;

public interface ITeacherRepository : IRepository<Teacher>, IGetAll<Teacher>
{
    ValueTask<Teacher> GetByPhoneNumberAsync(string phoneNumber);

    ValueTask<bool> UpdateImageAsync(long teacherId, string imagePath);

    ValueTask<Teacher> GetByEmailAsync(string email);

}
