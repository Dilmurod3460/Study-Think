using StudyThink.DataAccess.Common;
using StudyThink.DataAccess.Interfaces;
using StudyThink.Domain.Entities.Courses;

namespace StudyThink.Service.Interfaces.Courses;

public interface ICourseModulRepository : IRepository<CourseModul>,
    IGetAll<CourseModul>, ISearchable<CourseModul>
{
    public ValueTask<CourseModul> GetByNameAsync(string name);
}
