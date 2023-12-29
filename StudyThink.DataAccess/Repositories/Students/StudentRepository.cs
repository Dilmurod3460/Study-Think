using Dapper;
using StudyThink.DataAccess.Interfaces.Students;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Students;
using StudyThink.Domain.Enums;

namespace StudyThink.DataAccess.Repositories.Students;

public class StudentRepository : BaseRepository2, IStudentRepository
{
    public StudentRepository(string connectionString) : base(connectionString)
    {
    }

    public async ValueTask<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT COUNT(*) FROM Students";

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

    public async ValueTask<bool> CreateAsync(Student model)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO Students(FirstName, LastName,DateOfBirth,UserName,Password, Email,PhoneNumber, Gender, CreatedAt, UpdatedAt) " +
                $"VALUES (@FirstName, @LastName,'{model.DateOfBirth}',@UserName,@Password,@Email,@PhoneNumber,'{model.Gender}', @CreatedAt,@UpdatedAt)";

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
            string query = $"DELETE FROM Students WHERE Id={Id}";
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

    public async ValueTask<IEnumerable<Student>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = @"SELECT * FROM Students ORDER BY Id DESC 
                         OFFSET @SkipCount ROWS FETCH NEXT @PageSize ROWS ONLY";

            var parameters = new
            {
                SkipCount = @params.GetSkipCount(),
                PageSize = @params.PageSize
            };

            IEnumerable<Student> students = await _connection.QueryAsync<Student>(query, parameters);

            return students;
        }
        catch
        {
            return Enumerable.Empty<Student>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<Student> GetByEmailAsync(string email)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM Students WHERE Email = @Email";

            var parameters = new { Email = email };

            Student student = await _connection.QuerySingleOrDefaultAsync<Student>(query, parameters);

            return student;

        }
        catch (Exception)
        {
            return new Student();

        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public ValueTask<IEnumerable<Student>> GetByGenderAsync(Gender gender)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<Student> GetByIdAsync(long Id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM Students " +
                $"WHERE Id = {Id}";
            Student student = await _connection.ExecuteScalarAsync<Student>(query);
            return student;

        }
        catch (Exception)
        {
            return new Student();

        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<IEnumerable<Student>> GetByPhoneNumberAsync(string phoneNumber)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM Students WHERE PhoneNumber = @PhoneNumber";

            var parameters = new { PhoneNumber = phoneNumber };

            IEnumerable<Student> students = await _connection.QueryAsync<Student>(query, parameters);

            return students;
        }
        catch
        {
            return Enumerable.Empty<Student>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async ValueTask<Student> GetByUserNameAsync(string username)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "SELECT * FROM Students WHERE UserName = @Username";

            var parameters = new { Username = username };

            Student student = await _connection.QuerySingleOrDefaultAsync<Student>(query, parameters);

            return student;
        }
        catch
        {
            return new Student();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public ValueTask<(long ItemsCount, IEnumerable<Student>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<bool> UpdateAsync(Student model)
    {
        try
        {
            await _connection.OpenAsync();

            string query = @"UPDATE Students SET 
                            FirstName = @FirstName,
                            LastName = @LastName,
                            DateOfBirth = @DateOfBirth,
                            UserName = @UserName,
                            Password = @Password,
                            Email = @Email,
                            PhoneNumber = @PhoneNumber,
                            Gender = @Gender,
                            CreatedAt = @CreatedAt,
                            UpdatedAt = @UpdatedAt,
                            DeletedAt = @DeletedAt 
                            WHERE Id = @Id";

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

    public Task<bool> UpdateImageAsync(long studentId, string imagePath)
    {
        throw new NotImplementedException();
    }
}
