using Dapper;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Courses;
using StudyThink.Service.Interfaces.Courses;

namespace StudyThink.DataAccess.Repositories.Courses;

public class CourseReqRepository : BaseRepository2, ICourseReqRepository
{
    public CourseReqRepository(string connectionString) : base(connectionString)
    {
    }

    public async ValueTask<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT COUNT(*) FROM CourseRequirments";

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

    public async ValueTask<bool> CreateAsync(CourseRequirment model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO CourseRequirments(Requirments, CreatedAt, UpdatedAt) " +
                "VALUES (@Requirments, @CreatedAt, @UpdatedAt)";

            var patametrs = new
            {
                Requirments = model.Requirments,
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

            string query = "DELETE FROM CourseRequirements " +
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

    public async ValueTask<IEnumerable<CourseRequirment>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM CourseRequirements " +
                "ORDER BY Id OFFSET @Offset ROWS " +
                "FETCH NEXT @PageSize ROWS ONLY";

            var parameters = new
            {
                Offset = (@params.PageNumber - 1) * @params.PageSize,
                PageSize = @params.PageSize
            };

            var result = await _connection.QueryAsync<CourseRequirment>(query, parameters);

            return result;
        }
        catch
        {
            return Enumerable.Empty<CourseRequirment>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<CourseRequirment> GetByIdAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM CourseRequirements " +
                "WHERE Id = @Id";

            var parameters = new { Id };

            var result = await _connection.QueryFirstOrDefaultAsync<CourseRequirment>(query, parameters);

            return result;
        }
        catch
        {
            return new CourseRequirment();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<CourseRequirment> GetByNameAsync(string name)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM CourseRequirements " +
                "WHERE Requirments = @Name";

            var parameters = new { Name = name };

            var result = await _connection
                .QueryFirstOrDefaultAsync<CourseRequirment>(query, parameters);

            return result;
        }
        catch
        {
            return new CourseRequirment();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<(long ItemsCount, IEnumerable<CourseRequirment>)> SearchAsync(string search, PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string countQuery = "SELECT COUNT(*) FROM CourseRequirements " +
                "WHERE Requirments LIKE @Search";

            var countParameters = new { Search = $"%{search}%" };

            long totalCount = await _connection
                .ExecuteScalarAsync<long>(countQuery, countParameters);

            string searchQuery = "SELECT * FROM CourseRequirements " +
                "WHERE Requirments LIKE @Search ORDER BY Id " +
                "OFFSET @Offset ROWS FETCH NEXT @PageSize " +
                "ROWS ONLY";

            var searchParameters = new
            {
                Search = $"%{search}%",
                Offset = @params.GetSkipCount(),
                PageSize = @params.PageSize
            };

            var result = await _connection.QueryAsync<CourseRequirment>(searchQuery, searchParameters);

            return (totalCount, result);
        }
        catch
        {
            return (0, Enumerable.Empty<CourseRequirment>());
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<bool> UpdateAsync(CourseRequirment model)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "UPDATE CourseRequirements SET Requirments = @Requirments, CreatedAt = @CreatedAt, UpdatedAt = @UpdatedAt WHERE Id = @Id";

            var parameters = new
            {
                model.Id,
                model.Requirments,
                model.CreatedAt,
                model.UpdatedAt
            };

            int affectedRows = await _connection.ExecuteAsync(query, parameters);

            return affectedRows > 0;
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
}
