using Dapper;
using StudyThink.DataAccess.Interfaces.Admins;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Admins;
using static Dapper.SqlMapper;

namespace StudyThink.DataAccess.Repositories.Admins;

public class AdminRepository : BaseRepository2, IAdminRepository
{
    public AdminRepository(string connectionString) : base(connectionString)
    {
    }

    public async ValueTask<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT COUNT(*) FROM Admins";

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

    public async ValueTask<bool> CreateAsync(Admin model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO Admins(FirstName, LastName, PhoneNumber, Email, Password, Role, CreatedAt, UpdatedAt, DeletedAt) " +
                           $"VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @Password, '{model.Role.ToString()}', @CreatedAt, @UpdatedAt, @DeletedAt)";


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

            string query = $"DELETE FROM Admins WHERE Id = {Id}";

            var result = await _connection.ExecuteAsync(query);

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

    public async ValueTask<IEnumerable<Admin>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM Admins ORDER BY Id OFFSET " +
                "@Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            var parameters = new
            {
                Offset = @params.GetSkipCount(),
                PageSize = @params.PageSize
            };

            var result = await _connection.QueryAsync<Admin>(query, parameters);

            return result;
        }
        catch
        {
            return new List<Admin>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<Admin> GetByEmailAsync(string email)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM Admins WHERE Email = @Email";

            var parameters = new { Email = email };

            Admin admin = await _connection.QuerySingleOrDefaultAsync<Admin>(query, parameters);

            return admin;
        }
        catch
        {
            return new Admin();

        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<Admin> GetByIdAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM Admins WHERE Id = @Id";

            var result = await _connection.QuerySingleAsync<Admin>(query, new { Id = Id });
            return result;
        }
        catch
        {
            return new Admin();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public ValueTask<IEnumerable<Admin>> GetByPhoneNumberAsync(string phoneNumber)
    {
        throw new NotImplementedException();
    }

    public ValueTask<(long ItemsCount, IEnumerable<Admin>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<bool> UpdateAsync(Admin model)
    {
        try
        {
            var paramets = new
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password,
                Role = model.Role.ToString(),
                CreatedAt = model.CreatedAt,
                UpdatedAt = model.UpdatedAt,
                DeletedAt = model.DeletedAt
            };

            await _connection.OpenAsync();
            string query = $"UPDATE Admins SET FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber, Email = @Email, " +
                           $"Password = @Password, Role = @Role, CreatedAt = @CreatedAt, UpdatedAt = @UpdatedAt, DeletedAt = @DeletedAt " +
                           $"WHERE Id = @Id";

            var result = await _connection.ExecuteAsync(query, paramets);
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

}
