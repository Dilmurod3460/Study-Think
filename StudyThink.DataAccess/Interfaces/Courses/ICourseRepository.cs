using StudyThink.DataAccess.Interfaces;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Course;
using StudyThink.Domain.Entities.Courses;
using System.ComponentModel;

namespace StudyThink.Service.Interfaces.Courses;

public  interface ICourseRepository:IRepository<Course>
{
    ValueTask<IEnumerable<Course>> GetAllAsync(PaginationParams @params);
    ValueTask<IEnumerable<Course>> GetByNameAsync (string name);

}
