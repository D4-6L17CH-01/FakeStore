namespace Common.Contracts;

public interface IUser
{
    Task<ICollection<User>> GetAllAsync();
    Task<User> GetAsync();
    Task<User> InsertAsync(User usuario);
    Task<User> UpdateAsync(int id, User usuario);
    Task<bool> DeleteAsync(int id);
}
