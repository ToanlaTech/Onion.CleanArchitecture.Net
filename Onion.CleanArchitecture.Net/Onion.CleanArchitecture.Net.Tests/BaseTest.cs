using System;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Onion.CleanArchitecture.Net.Application.Interfaces;
using Onion.CleanArchitecture.Net.Application.Interfaces.Services.Catalog;
using Onion.CleanArchitecture.Net.Domain.Caching;
using Onion.CleanArchitecture.Net.Domain.Common;
using Onion.CleanArchitecture.Net.Domain.Infrastructure;
using Onion.CleanArchitecture.Net.Infrastructure.Persistence.Contexts;
using Onion.CleanArchitecture.Net.Infrastructure.Persistence.Repositories;
using Onion.CleanArchitecture.Net.Infrastructure.Persistence.Services.Caching;
using Onion.CleanArchitecture.Net.Infrastructure.Persistence.Services.Catalog;
using Onion.CleanArchitecture.Net.Infrastructure.Shared.Services;
using Onion.CleanArchitecture.Net.WebApp.Server.Services;

namespace Onion.CleanArchitecture.Net.Tests;

public partial class BaseTest
{
    private static ServiceProvider? _serviceProvider;
    public ServiceProvider ServiceProvider => _serviceProvider!;
    private static void Init()
    {
        var services = new ServiceCollection();
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseInMemoryDatabase("InMemoryDbForTesting");
        });
        var memoryCache = new MemoryCache(new MemoryCacheOptions());
        services.AddScoped<IShortTermCacheManager, PerRequestCacheManager>();

        services.AddSingleton<ICacheKeyManager, CacheKeyManager>();
        services.AddSingleton<IMemoryCache>(memoryCache);
        services.AddSingleton<IStaticCacheManager, MemoryCacheManager>();
        services.AddSingleton<ILocker, MemoryCacheLocker>();
        services.AddSingleton<MemoryCacheLocker>();

        services.AddTransient(typeof(IConcurrentCollection<>), typeof(ConcurrentTrie<>));

        var memoryDistributedCache = new MemoryDistributedCache(new TestMemoryDistributedCacheoptions());
        services.AddSingleton<IDistributedCache>(memoryDistributedCache);
        services.AddScoped<MemoryDistributedCacheManager>();
        services.AddSingleton(new DistributedCacheLocker(memoryDistributedCache));
        services.AddHttpContextAccessor();
        // authentication
        services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
        // date time service
        services.AddTransient<IDateTimeService, DateTimeService>();
        //repositories
        services.AddTransient(typeof(IRepository<>), typeof(EntityRepository<>));
        //services
        services.AddTransient<IProductService, ProductService>();
        // Missing part: Build the service provider
        _serviceProvider = services.BuildServiceProvider();
    }

    static BaseTest()
    {
        Init();
    }

    protected static T GetService<T>() where T : notnull
    {
        return _serviceProvider!.GetRequiredService<T>();
    }

    protected static T GetService<T>(IServiceScope scope)
    {
        return scope.ServiceProvider.GetService<T>()!;
    }

    public async Task TestCrud<TEntity>(TEntity baseEntity, Func<TEntity, Task> insert, TEntity updateEntity, Func<TEntity, Task> update, Func<int, Task<TEntity>> getById, Func<TEntity, TEntity, bool> equals, Func<TEntity, Task> delete) where TEntity : AuditableBaseEntity
    {
        baseEntity.Id = 0;

        await insert(baseEntity);
        baseEntity.Id.Should().BeGreaterThan(0);

        updateEntity.Id = baseEntity.Id;
        await update(updateEntity);

        var item = await getById(baseEntity.Id);
        item.Should().NotBeNull();
        equals(updateEntity, item).Should().BeTrue();

        await delete(baseEntity);
        item = await getById(baseEntity.Id);
        item.Should().BeNull();
    }

    #region Nested classes
    private class TestMemoryDistributedCache
    {
        public TestMemoryDistributedCache()
        {
        }
    }

    private class TestMemoryDistributedCacheoptions : IOptions<MemoryDistributedCacheOptions>
    {
        public MemoryDistributedCacheOptions Value => new();
    }
    #endregion
}
