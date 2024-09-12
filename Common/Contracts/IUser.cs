namespace Common.Contracts;

public interface IUser
{
    Task<ICollection<User>> GetAllAsync();
    Task<User> GetAsync(int id);
    Task<User> InsertAsync(User usuario);
    Task<User> UpdateAsync(int id, User usuario);
    Task<User> DeleteAsync(int id);
}
