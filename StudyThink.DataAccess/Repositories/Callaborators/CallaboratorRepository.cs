using Dapper;
using StudyThink.DataAccess.Interfaces.Coloborators;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Callaborators;

namespace StudyThink.DataAccess.Repositories.Callaborators;

public class CallaboratorRepository : BaseRepository2, ICalloboratorRepository
{
    public CallaboratorRepository(string connectionString) : base(connectionString)
    {
    }

    public async ValueTask<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT COUNT(*) FROM Callaborators";

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

    public async ValueTask<bool> CreateAsync(Callaborator model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO Callaborators(Name, ImagePath, Description, Email, PhoneNumber) " +
                "VALUES (@Name, @ImagePath, @Description, @Email, @PhoneNumber)";

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

            string query = "DELETE FROM Callaborators WHERE Id = @Id";

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

    public async ValueTask<IEnumerable<Callaborator>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM Callaborators ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            var parameters = new
            {
                Offset = @params.GetSkipCount(),
                PageSize = @params.PageSize
            };

            IEnumerable<Callaborator> callaborators = await _connection.QueryAsync<Callaborator>(query, parameters);

            return callaborators;
        }
        catch
        {
            return Enumerable.Empty<Callaborator>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<Callaborator> GetByIdAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM Callaborators WHERE Id = @Id";

            var parameters = new { Id };

            Callaborator? callaborator = await _connection.QueryFirstOrDefaultAsync<Callaborator>(query, parameters);

            return callaborator;

        }
        catch
        {
            return new Callaborator();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<bool> UpdateAsync(Callaborator model)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "UPDATE Callaborators SET Name = @Name, ImagePath = @ImagePath, Description = @Description," +
                " Email = @Email, PhoneNumber = @PhoneNumber WHERE Id = @Id";

            var parameters = new
            {
                model.Id,
                model.Name,
                model.ImagePath,
                model.Description,
                model.Email,
                model.PhoneNumber
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
