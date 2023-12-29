using Dapper;
using StudyThink.DataAccess.Interfaces.Categories;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Categories;

namespace StudyThink.DataAccess.Repositories.Categories;

public class CategoryRepository : BaseRepository2, ICategoryRepository
{
    public CategoryRepository(string connectionString) : base(connectionString)
    {
    }

    public async ValueTask<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT COUNT(*) FROM Categories";

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

    public async ValueTask<bool> CreateAsync(Category model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO Categories(Name, Description) " +
                "VALUES (@Name, @Description)";

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
            string query = $"DELETE FROM Categories WHERE Id={Id}";
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

    public async ValueTask<IEnumerable<Category>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM Categories ORDER BY Id OFFSET" +
                " @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            var parameters = new
            {
                Offset = @params.GetSkipCount(),
                PageSize = @params.PageSize
            };

            IEnumerable<Category> categories = await _connection.QueryAsync<Category>(query, parameters);

            return categories;
        }
        catch (Exception)
        {
            return Enumerable.Empty<Category>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<Category> GetByIdAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM Categories " +
                $"WHERE Id = {Id}";
            Category? category = await _connection.QueryFirstOrDefaultAsync<Category>(query);
            return category;

        }
        catch (Exception)
        {
            return new Category();

        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public ValueTask<(long ItemsCount, IEnumerable<Category>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<bool> UpdateAsync(Category model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"Update Categories SET Name=@Name,Description=@Description " +
                $"Where Id = @Id";

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

    public Task<bool> UpdateImageAsync(long categoryId, string imagePath)
    {
        throw new NotImplementedException();
    }
}
