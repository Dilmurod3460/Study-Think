using Dapper;
using StudyThink.DataAccess.Interfaces.Payments;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Payments;

namespace StudyThink.DataAccess.Repositories.Payments;

public class PaymentRepository : BaseRepository2, IPaymentRepository
{
    public PaymentRepository(string connectionString) : base(connectionString)
    {
    }

    public async ValueTask<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT COUNT(*) FROM Payment";

            long result = await _connection.ExecuteScalarAsync<long>(query);
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

    public async ValueTask<bool> CreateAsync(Payment model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"INSERT INTO Payment(Type, Status, Description, CourseId) " +
                $"VALUES (@Type, @Status, @Description, {model.CourseId})";

            var result = await _connection.ExecuteAsync(query, query);

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

            string query = $"DELETE FROM Payment WHERE Id = {Id}";

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

    public async ValueTask<IEnumerable<Payment>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM Payment ORDER BY Id DESC" +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize}";

            var result = await _connection.QueryAsync<Payment>(query);

            return result;
        }
        catch
        {
            return new List<Payment>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<Payment> GetByIdAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM Admins WHERE Id = @Id";

            var result = await _connection.QuerySingleAsync<Payment>(query, new { Id = Id });
            return result;
        }
        catch
        {
            return new Payment();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<bool> UpdateAsync(Payment model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE Payment SET Type = @Type, Status = @Status, " +
                           $"Description = @Description, CourseId = @CourseId " +
                           $"WHERE Id = {model.Id}";

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
}
