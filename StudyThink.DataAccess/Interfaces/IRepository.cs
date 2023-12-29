namespace StudyThink.DataAccess.Interfaces;

public interface IRepository<T> where T : class
{
    ValueTask<long> CountAsync();
    ValueTask<T> GetByIdAsync(long Id);
    ValueTask<bool> DeleteAsync(long Id);
    ValueTask<bool> UpdateAsync(T model);
    ValueTask<bool> CreateAsync(T model);
}