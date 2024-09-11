using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Onion.CleanArchitecture.Net.Domain.Caching;
using Onion.CleanArchitecture.Net.Domain.Infrastructure;
using Onion.CleanArchitecture.Net.Infrastructure.Persistence.Contexts;
using Onion.CleanArchitecture.Net.Infrastructure.Persistence.Services.Caching;

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
