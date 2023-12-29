using Dapper;
using StudyThink.DataAccess.Interfaces.Teachers;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Course;
using StudyThink.Domain.Entities.Teachers;
using System.ComponentModel.DataAnnotations;

namespace StudyThink.DataAccess.Repositories.Teachers
{
    public class TeacherRepository : BaseRepository2, ITeacherRepository
    {
        public TeacherRepository(string connectionString) : base(connectionString)
        {
        }

        public async ValueTask<bool> CreateAsync(Teacher model)
        {
            try
            {
                await _connection.OpenAsync();

                DynamicParameters @params = new DynamicParameters();
                //@params.Add("@FirstName", model.FirstName);
                //@params.Add("@LastName", model.LastName);
                //@params.Add("@DataOfBirth", model.DateOfBirth);
                //@params.Add("@ImagePath", model.ImagePath);
                //@params.Add("@Level", model.Level);
                //@params.Add("@Description", model.Description);
                //@params.Add("@Gender");
                //@params.Add("@Email", model.Email);
                //@params.Add("@PhoneNumber", model.PhoneNumber);
                //@params.Add("@Password", model.Password);

                //string query = @"insert into Teachers (FirstName,LastName,DataOfBirth,ImagePath,Level,Description,Gender,Email,PhoneNumber,Password)" +
                //    "values (@FirstName,@LastName,@DataOfBirth,@ImagePath,@Level,@Description,@Email,@PhoneNumber,@Password)";

                string query = "insert into teachers (FirstName,LastName,DataOfBirth,ImagePath,Level,Description,Gender,Email,PhoneNumber,Password)" +
                    $"values('{model.FirstName}','{model.LastName}',GetDate(),'{model.ImagePath}','{model.Level}','{model.Description}','{model.Gender}','{model.Email}','{model.PhoneNumber}','{model.Password}');";

                int result = await _connection.ExecuteAsync(query);

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

        public async ValueTask<long> CountAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = @"select count(*) from teachers";

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

        public async ValueTask<bool> DeleteAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                DynamicParameters @params = new DynamicParameters();
                @params.Add("@Id", Id);

                string query = @"delete from teachers where Id = @Id";

                int result = await _connection.ExecuteAsync(query, @params);

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

        public async ValueTask<IEnumerable<Teacher>> GetAllAsync(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT * FROM teachers ORDER BY Id " +
                "OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                var parameters = new
                {
                    Offset = @params.GetSkipCount(),
                    PageSize = @params.PageSize
                };

                IEnumerable<Teacher> result = await _connection.QueryAsync<Teacher>(query, parameters);

                return result;
            }
            catch
            {
                return Enumerable.Empty<Teacher>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<Teacher> GetByIdAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                DynamicParameters @params = new DynamicParameters();
                @params.Add("@Id", Id);

                string query = $"select * from teachers where Id = {Id}";

                Teacher? teacher = await _connection.QueryFirstOrDefaultAsync<Teacher>(query);

                return teacher;
            }
            catch
            {
                return new Teacher();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<Teacher> GetByPhoneNumberAsync(string phoneNumber)
        {
            try
            {
                await _connection.OpenAsync();

                DynamicParameters @params = new DynamicParameters();
                @params.Add("PhoneNumber", phoneNumber);

                string query = "select * from teachers where phoneNumber = @PhoneNumber";

                Teacher? teacher = await _connection.ExecuteScalarAsync<Teacher>(query, @params);

                return teacher;
            }
            catch
            {
                return new Teacher();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<bool> UpdateAsync(Teacher model)
        {
            try
            {
                await _connection.OpenAsync();

                DynamicParameters @params = new DynamicParameters();
                @params.Add("@FirstName", model.FirstName);
                @params.Add("@LastName", model.LastName);
                @params.Add("@DataOfBirth", model.DateOfBirth);
                @params.Add("@ImagePath", model.ImagePath);
                @params.Add("@Level", model.Level);
                @params.Add("@Description", model.Description);
                @params.Add("@Gender");
                @params.Add("@Email", model.Email);
                @params.Add("@PhoneNumber", model.PhoneNumber);
                @params.Add("@Password", model.Password);
                @params.Add("@UpdatedAt", model.UpdatedAt);

                string query = @"update teachers set FirstName = @FirstName,@LastName = LastName,DataOfBirth = @DataOfBirth,ImagePath = @ImagePath,Level = @Level" +
                    "Description = @Description,Gender = @Gender,Email = @Email,PhoneNumber = @PhoneNumber,Password = @Password,UpdatedAt = @UpdatedAt";

                int result = await _connection.ExecuteAsync(query, @params);

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

        public async ValueTask<bool> UpdateImageAsync(long teacherId, string imagePath)
        {
            try
            {
                await _connection.OpenAsync();

                DynamicParameters @params = new DynamicParameters();
                @params.Add("@Id", teacherId);
                @params.Add("@ImagePath", imagePath);

                string query = "update teachers set ImagePath = @ImagePath where Id = @Id";

                int result = await _connection.ExecuteAsync(query, @params);

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

        public async ValueTask<Teacher> GetByEmailAsync(string email)
        {
            try
            {
                await _connection.OpenAsync();

                DynamicParameters @params = new DynamicParameters();
                @params.Add("Email", email);

                string query = "select * from teachers where Email = @email";

                Teacher teacher = await _connection.ExecuteScalarAsync<Teacher>(query, @params);

                return teacher;
            }
            catch
            {
                return new Teacher();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }
    }
}
