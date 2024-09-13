namespace Common.Contracts;

public interface IProducts
{
    Task<ICollection<Product>> GetAllAsync();
    Task<Product> GetAsync(int id);
    Task<Product> InsertAsync(Product producto);
    Task<Product> UpdateAsync(int id , Product producto);
    Task<Product> DeleteAsync(int id);
}
