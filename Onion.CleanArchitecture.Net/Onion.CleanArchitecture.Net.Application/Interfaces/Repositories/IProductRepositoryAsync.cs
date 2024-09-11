using Onion.CleanArchitecture.Net.Application.Features.Products.Queries.GetAllProducts;
using Onion.CleanArchitecture.Net.Application.Wrappers;
using Onion.CleanArchitecture.Net.Domain.Entities.Catalog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Onion.CleanArchitecture.Net.Application.Interfaces.Repositories
{
    public interface IProductRepositoryAsync : IGenericRepositoryAsync<Product>
    {
        Task<int> DeleteRangeAsync(List<int> ids);
        Task<PagedList<Product>> GetPagedProductsAsync(GetAllProductsParameter parameter);
    }
}
