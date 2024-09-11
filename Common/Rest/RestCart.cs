namespace Common.Rest;

public class RestCart : ICart
{
    public RestCart(string baseUrl, string token) { http = new HttpHelper(baseUrl, token); }
    private readonly HttpHelper http;

    public async Task<bool> DeleteAsync(int id)
        => await http.DeleteAsync($"carts/{id}");

    public Task<ICollection<Cart>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Cart> GetAsync(int userid)
    {
        throw new NotImplementedException();
    }

    public Task<Cart> InsertAsync(Cart carrito)
    {
        throw new NotImplementedException();
    }

    public Task<Cart> PatchAsync(int id, Cart carrito)
    {
        throw new NotImplementedException();
    }

    public Task<Cart> UpdateAsync(int id, Cart carrito)
    {
        throw new NotImplementedException();
    }
}
