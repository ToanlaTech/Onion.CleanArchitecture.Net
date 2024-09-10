using Microsoft.EntityFrameworkCore;
using Onion.CleanArchitecture.Net.Application.Features.Products.Queries.GetAllProducts;
using Onion.CleanArchitecture.Net.Application.Interfaces;
using Onion.CleanArchitecture.Net.Application.Interfaces.Repositories;
using Onion.CleanArchitecture.Net.Application.Wrappers;
using Onion.CleanArchitecture.Net.Domain.Entities;
using Onion.CleanArchitecture.Net.Infrastructure.Persistence.Contexts;
using Onion.CleanArchitecture.Net.Infrastructure.Persistence.Repository;
using Onion.CleanArchitecture.Net.Infrastructure.Shared.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.CleanArchitecture.Net.Infrastructure.Persistence.Repositories
{
    public class ProductRepositoryAsync : GenericRepositoryAsync<Product>, IProductRepositoryAsync
    {
        private readonly DbSet<Product> _products;
        protected readonly IRepository<Product> _productRepository;

        public ProductRepositoryAsync(
            ApplicationDbContext dbContext,
            IRepository<Product> productRepository
            ) : base(dbContext)
        {
            _products = dbContext.Set<Product>();
            _productRepository = productRepository;
        }

        public async Task<bool> IsUniqueBarcodeAsync(string barcode)
        {
            var query = from p in _productRepository.Table
                        where p.Barcode == barcode
                        select p;
            return await query.CountAsync() == 0;
            //return _products
            //    .AllAsync(p => p.Barcode != barcode);
        }

        public async Task<int> DeleteRangeAsync(List<int> ids)
        {
            var products = await _products.Where(p => ids.Contains(p.Id)).ToListAsync();
            _products.RemoveRange(products);
            return products.Count;
        }

        public async Task<PagedList<Product>> GetPagedProductsAsync(GetAllProductsParameter request)
        {
            var productQuery = _products.AsQueryable();
            if (request._filter != null && request._filter.Count > 0)
            {
                productQuery = MethodExtensions.ApplyFilters(productQuery, request._filter);
            }

            return await PagedList<Product>.ToPagedList(productQuery.OrderByDynamic(request._sort, request._order).AsNoTracking(), request._start, request._end);
        }
    }
}
