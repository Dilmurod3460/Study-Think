using Dapper;
using StudyThink.DataAccess.Interfaces.Payments;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Payments;

namespace StudyThink.DataAccess.Repositories.Payments;

public class PaymentDetailsRepository : BaseRepository2, IPaymentDetailsRepository
{
    public PaymentDetailsRepository(string connectionString) : base(connectionString)
    {
    }

    public async ValueTask<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT COUNT(*) FROM PaymentDetails";

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

    public async ValueTask<bool> CreateAsync(PaymentDetails model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"INSERT INTO PaymentDetails(CardHolderName,CardNumber,ExpirationDate,CardCodeCVV," +
                $"CardPoneNumber,StudentId,CreatedAt,IsPaid,CourseId) " +
                $"VALUES(@CardHolderName,@CardNumber,@ExpirationDate,@CardCodeCVV,@CardPoneNumber,@StudentId,@CreatedAt," +
                $"@IsPaid,@CourseId)";
            var result = await _connection.ExecuteAsync(query, model);
            return result > 0;
        }
        catch (Exception)
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
            string query = $"DELETE FROM PaymentDetails WHERE Id={Id}";
            var result = await _connection.ExecuteAsync(query);
            return result > 0;
        }
        catch (Exception)
        {

            return false;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<IEnumerable<PaymentDetails>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM PaymentDetails ORDER BY Id DESC" +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize}";

            var result = await _connection.QueryAsync<PaymentDetails>(query);

            return result;
        }
        catch
        {
            return new List<PaymentDetails>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<PaymentDetails> GetByIdAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM PaymentDetails " +
                $"WHERE Id = {Id}";
            PaymentDetails paymentDetails = await _connection.ExecuteScalarAsync<PaymentDetails>(query);
            return paymentDetails;

        }
        catch (Exception)
        {
            return new PaymentDetails();

        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<bool> UpdateAsync(PaymentDetails model)
    {

        try
        {
            await _connection.OpenAsync();
            string query = $"Update Categories SET CardHolderName='{model.CardHolderName}',CardNumber='{model.CardNumber}',ExpirationDate='{model.ExpirationDate}'," +
                $"CardCodeCVV='{model.CardCodeCVV}',CardPhoneNumber='{model.CardPhoneNumber}',StudentId={model.StudentId},CreatedAt={model.CreatedAt}," +
                $"IsPaid='{model.IsPaid}',CourseId={model.CourseId}";
            var result = await _connection.ExecuteAsync(query, model);
            return result > 0;
        }
        catch (Exception)
        {

            return false;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
