using Dapper;
using StudyThink.DataAccess.Interfaces;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Courses;
using StudyThink.Service.Interfaces.Courses;

namespace StudyThink.DataAccess.Repositories.Courses;

public class CourseModulRepository : BaseRepository2, ICourseModulRepository
{
    public CourseModulRepository(string connectionString) : base(connectionString)
    {
    }

    public async ValueTask<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT COUNT(*) FROM CourseModuls";

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

    public async ValueTask<bool> CreateAsync(CourseModul model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO CourseModuls(Name, CourseId, CreatedAt, UpdatedAt) " +
                "VALUES (@Name, @CourseId, @CreatedAt, @UpdatedAt)";

            var patametrs = new
            {
                Name = model.Name,
                CourseId = model.CourseId,
                CreatedAt = model.CreatedAt,
                UpdatedAt = model.UpdatedAt
            };

            var result = await _connection.ExecuteAsync(query, patametrs);

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

            string query = "DELETE FROM CourseModuls WHERE Id = @Id";

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

    public async ValueTask<IEnumerable<CourseModul>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM CourseModuls ORDER BY Id " +
                "OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            var parameters = new
            {
                Offset = @params.GetSkipCount(),
                PageSize = @params.PageSize
            };

            var result = await _connection.QueryAsync<CourseModul>(query, parameters);

            return result;
        }
        catch
        {
            return Enumerable.Empty<CourseModul>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<CourseModul> GetByIdAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM CourseModuls " +
                "WHERE Id = @Id";

            var parameters = new { Id };

            var result = await _connection.QueryFirstOrDefaultAsync<CourseModul>(query, parameters);

            return result;
        }
        catch
        {
            return new CourseModul();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<CourseModul> GetByNameAsync(string name)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM CourseModuls " +
                "WHERE Name = @Name";

            var parameters = new { Name = name };

            var result = await _connection.QueryFirstOrDefaultAsync<CourseModul>(query, parameters);

            return result;
        }
        catch
        {
            return new CourseModul();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<(long ItemsCount, IEnumerable<CourseModul>)> SearchAsync(string search, PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string countQuery = "SELECT COUNT(*) FROM CourseModuls WHERE Name LIKE @Search";

            var countParameters = new { Search = $"%{search}%" };

            long totalCount = await _connection.ExecuteScalarAsync<long>(countQuery, countParameters);

            string searchQuery = "SELECT * FROM CourseModuls " +
                "WHERE Name LIKE @Search ORDER BY Id " +
                "OFFSET @Offset ROWS FETCH NEXT @PageSize " +
                "ROWS ONLY";

            var searchParameters = new
            {
                Search = $"%{search}%",
                Offset = (@params.PageNumber - 1) * @params.PageSize,
                PageSize = @params.PageSize
            };

            var result = await _connection.QueryAsync<CourseModul>(searchQuery, searchParameters);

            return (totalCount, result);

        }
        catch
        {
            return (0, Enumerable.Empty<CourseModul>());
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<bool> UpdateAsync(CourseModul model)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "UPDATE CourseModuls " +
                "SET Name = @Name, CourseId = @CourseId, " +
                "CreatedAt = @CreatedAt, UpdatedAt = @UpdatedAt " +
                "WHERE Id = @Id";

            var parameters = new
            {
                model.Id,
                model.Name,
                model.CourseId,
                model.CreatedAt,
                model.UpdatedAt
            };

            int result = await _connection.ExecuteAsync(query, parameters);

            _connection.Close();

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

    async ValueTask<CourseModul> IRepository<CourseModul>.GetByIdAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Select * from CourseMudul" +
                "where Id=@Id";
            var parametrs = new { Id };
            CourseModul? courseModul = await _connection
                .QueryFirstOrDefaultAsync<CourseModul>(query, parametrs);

            return courseModul;
        }
        catch
        {
            return new CourseModul();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
