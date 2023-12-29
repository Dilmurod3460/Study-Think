using StudyThink.DataAccess.Common;
using StudyThink.Domain.Entities.Students;
using StudyThink.Domain.Enums;

namespace StudyThink.DataAccess.Interfaces.Students;

public interface IStudentRepository : IRepository<Student>,
    IGetAll<Student>, ISearchable<Student>
{
    ValueTask<Student> GetByUserNameAsync(string username);

    ValueTask<Student> GetByEmailAsync(string email);

    ValueTask<IEnumerable<Student>> GetByGenderAsync(Gender gender);

    ValueTask<IEnumerable<Student>> GetByPhoneNumberAsync(string phoneNumber);

    public Task<bool> UpdateImageAsync(long studentId, string imagePath);

}
