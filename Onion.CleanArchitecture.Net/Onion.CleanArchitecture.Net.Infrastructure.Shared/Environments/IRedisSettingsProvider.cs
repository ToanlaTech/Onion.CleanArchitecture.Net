using StackExchange.Redis.Extensions.Core.Configuration;

namespace Onion.CleanArchitecture.Net.Infrastructure.Shared.Environments
{
    public interface IRedisSettingsProvider
    {
        RedisConfiguration GetRedisConfiguration();
    }
}
