namespace Common.Rest;

public class RestProduct : IProducts
{
    private readonly HttpHelper http;
    public RestProduct(string baseUrl, string token)
    {
        http = new HttpHelper(baseUrl, token);
    }
    public async Task<ICollection<Product>> GetAllAsync()
        => await http.GetAsync<ICollection<Product>>("products");

    public async Task<Product> GetAsync(int id)
        => await http.GetAsync<Product>($"products/{id}");

    public async Task<Product> InsertAsync(Product producto)
        => await http.PostAsync<Product, Product>($"products", producto);
    public async Task<Product> UpdateAsync(int id, Product producto)
        => await http.PutAsync<Product, Product>($"products/{id}", producto);
    public async Task<Product> DeleteAsync(int id)
        => await http.DeleteAsync<Product>($"products/{id}");
}
