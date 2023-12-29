using Dapper;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Courses;
using StudyThink.Service.Interfaces.Courses;

namespace StudyThink.DataAccess.Repositories.Courses;

public class CourseRepository : BaseRepository2, ICourseRepository
{
    public CourseRepository(string connectionString) : base(connectionString)
    {
    }

    public async ValueTask<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT COUNT(*) FROM Courses";

            long result = await _connection.QuerySingleAsync<long>(query);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<bool> CreateAsync(Course model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"INSERT INTO Courses(Name, Description, CategoryId, Price, ImagePath, TotalPrice, Lessons, Duration, Language, DiscountPrice, CourseReqId, CreatedAt, UpdatedAt) " +
                $"VALUES (@Name, @Description, {model.CategoryId}, @Price, @ImagePath, @TotalPrice, @Lessons, @Duration, @Language, @DiscountPrice, {model.CourseReqId}, @CreatedAt, UpdatedAt)";

            var result = await _connection.ExecuteAsync(query, model);

            return result > 0;
        }
        catch
        {
            return false;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<bool> DeleteAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "DELETE FROM Courses " +
                "WHERE Id = @Id";

            var parameters = new { Id };

            int result = await _connection.ExecuteAsync(query, parameters);

            return result > 0;
        }
        catch
        {
            return false;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<IEnumerable<Course>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM Courses " +
                "ORDER BY Id OFFSET @Offset ROWS " +
                "FETCH NEXT @PageSize ROWS ONLY";

            var parameters = new
            {
                Offset = @params.GetSkipCount(),
                PageSize = @params.PageSize
            };

            IEnumerable<Course> courses = await _connection.QueryAsync<Course>(query, parameters);

            return courses;
        }
        catch
        {
            return Enumerable.Empty<Course>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<Course> GetByIdAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM Courses " +
                "WHERE Id = @Id";

            var parameters = new { Id };

            Course? course = await _connection
                .QueryFirstOrDefaultAsync<Course>(query, parameters);

            return course;
        }
        catch
        {
            return new Course();
        }
        finally
        {
            await _connection.OpenAsync();
        }
    }

    public async ValueTask<IEnumerable<Course>> GetByNameAsync(string name)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM Courses " +
                "WHERE Name = @Name";

            var parameters = new { Name = name };

            var result = await _connection.QueryAsync<Course>(query, parameters);

            return result;
        }
        catch
        {
            return Enumerable.Empty<Course>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<(long ItemsCount, IEnumerable<Course>)> SearchAsync(string search, PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string countQuery = "SELECT COUNT(*) FROM Courses " +
                "WHERE Name LIKE @Search";

            var countParameters = new { Search = $"%{search}%" };

            long totalCount = await _connection
                .ExecuteScalarAsync<long>(countQuery, countParameters);

            string searchQuery = "SELECT * FROM Courses " +
                "WHERE Name LIKE @Search ORDER BY Id " +
                "OFFSET @Offset ROWS FETCH NEXT @PageSize " +
                "ROWS ONLY";

            var searchParameters = new
            {
                Search = $"%{search}%",
                Offset = @params.GetSkipCount(),
                PageSize = @params.PageSize
            };

            var result = await _connection.QueryAsync<Course>(searchQuery, searchParameters);

            return (totalCount, result);
        }
        catch
        {
            return (0, Enumerable.Empty<Course>());
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<bool> UpdateAsync(Course model)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "UPDATE Courses " +
                "SET Name = @Name, Description = @Description, " +
                "CategoryId = @CategoryId, Price = @Price, ImagePath = @ImagePath, " +
                "TotalPrice = @TotalPrice, Lessons = @Lessons, Duration = @Duration, " +
                "Language = @Language, DiscountPrice = @DiscountPrice, CreatedAt = @CreatedAt, " +
                "UpdatedAt = @UpdatedAt, CourseReqId = @CourseReqId " +
                "WHERE Id = @Id";

            var parameters = new
            {
                model.Id,
                model.Name,
                model.Description,
                model.CategoryId,
                model.Price,
                model.ImagePath,
                model.TotalPrice,
                model.Lessons,
                model.Duration,
                model.Language,
                model.DiscountPrice,
                model.CreatedAt,
                model.UpdatedAt,
                model.CourseReqId
            };

            int result = await _connection.ExecuteAsync(query, parameters);

            return result > 0;
        }
        catch
        {
            return false;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public ValueTask<bool> UpdateImageAsync(long categoryId, string imagePath)
    {
        throw new NotImplementedException();
    }
}
