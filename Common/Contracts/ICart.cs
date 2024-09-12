namespace Common.Contracts;

public interface ICart
{
    Task<ICollection<Cart>> GetAllAsync();
    Task<Cart> GetAsync(int cartid);
    Task<Cart> GetUserAsync(int userid);
    Task<Cart> InsertAsync(Cart carrito);
    Task<Cart> UpdateAsync(int id, Cart carrito);
    Task<Cart> PatchAsync(int id, Cart carrito);
    Task<Cart> DeleteAsync(int id);
}
