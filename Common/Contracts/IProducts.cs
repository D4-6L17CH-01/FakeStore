namespace Common.Contracts;

public interface IProducts
{
    Task<ICollection<Product>> GetAllAsync();
    Task<Product> GetAsync();
    Task<Product> InsertAsync(Product producto);
    Task<Product> UpdateAsync(int id , Product producto);
    Task<bool> DeleteAsync(int id);
}
