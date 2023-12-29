using Dapper;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Course;
using StudyThink.Service.Interfaces.Courses;

namespace StudyThink.DataAccess.Repositories.Courses;

public class CourseCommentRepository : BaseRepository2, ICourseCommentRepository
{
    public CourseCommentRepository(string connectionString) : base(connectionString)
    {
    }

    public async ValueTask<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT COUNT(*) FROM CourseComments";

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

    public async ValueTask<bool> CreateAsync(CourseComment model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO CourseComments(Comment, StudentId, CourseId, AdminId, CreatedAt, UpdatedAt) " +
                "VALUES (@Comment, @StudentId, @CourseId, @AdminId, @CreatedAt, @UpdatedAt)";

            var parametrs = new
            {
                Comment = model.Comment,
                StudentId = model.StudentId,
                CourseId = model.CourseId,
                AdminId = model.AdminId,
                CreatedAt = model.CreatedAt,
                UpdatedAt = model.UpdatedAt
            };

            var result = await _connection.ExecuteAsync(query, parametrs);

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

            string query = "DELETE FROM CourseComments WHERE Id = @Id";

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

    public async ValueTask<IEnumerable<CourseComment>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM CourseComments ORDER BY Id " +
                "OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            var parameters = new
            {
                Offset = @params.GetSkipCount(),
                PageSize = @params.PageSize
            };

            IEnumerable<CourseComment> courseComments = await _connection.QueryAsync<CourseComment>(query, parameters);

            return courseComments;
        }
        catch
        {
            return Enumerable.Empty<CourseComment>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<CourseComment> GetByComment(string comment)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM CourseComments " +
                            "WHERE Comment = @Comment";

            var parameters = new { Comment = comment };

            CourseComment? courseComment = await _connection.QueryFirstOrDefaultAsync<CourseComment>(query, parameters);

            return courseComment;
        }
        catch
        {
            return new CourseComment();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<CourseComment> GetByIdAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM CourseComments WHERE Id = @Id";

            var parameters = new { Id };

            var result = await _connection.
                QueryFirstOrDefaultAsync<CourseComment>(query, parameters);

            return result;
        }
        catch
        {
            return new CourseComment();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<(long ItemsCount, IEnumerable<CourseComment>)> SearchAsync(string search, PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string countQuery = "SELECT COUNT(*) FROM CourseComments WHERE Comment LIKE @Search";

            var countParameters = new { Search = $"%{search}%" };

            long totalCount = await _connection.ExecuteScalarAsync<long>(countQuery, countParameters);

            string searchQuery = "SELECT * FROM CourseComments WHERE Comment " +
                "LIKE @Search ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            var searchParameters = new
            {
                Search = $"%{search}%",
                Offset = @params.GetSkipCount(),
                PageSize = @params.PageSize
            };

            var searchResults = await _connection
                .QueryAsync<CourseComment>(searchQuery, searchParameters);

            return (totalCount, searchResults);
        }
        catch
        {
            return (0, Enumerable.Empty<CourseComment>());
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<bool> UpdateAsync(CourseComment model)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "UPDATE CourseComments SET " +
                "Comment = @Comment, StudentId = @StudentId, " +
                "CourseId = @CourseId, CreatedAt = @CreatedAt, " +
                "UpdatedAt = @UpdatedAt, AdminId = @AdminId " +
                "WHERE Id = @Id";

            var parameters = new
            {
                model.Id,
                model.Comment,
                model.StudentId,
                model.CourseId,
                model.CreatedAt,
                model.UpdatedAt,
                model.AdminId
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
