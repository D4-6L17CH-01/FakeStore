using Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Rest;

public class RestProduct : IProducts
{
    private readonly HttpHelper;
    public RestProduct()
    {
                
    }
    public Task<ICollection<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> InsertAsync(Product producto)
    {
        throw new NotImplementedException();
    }

    public Task<Product> UpdateAsync(int id, Product producto)
    {
        throw new NotImplementedException();
    }
    public Task<bool> DeleteAsync(int id)
        => 
}
