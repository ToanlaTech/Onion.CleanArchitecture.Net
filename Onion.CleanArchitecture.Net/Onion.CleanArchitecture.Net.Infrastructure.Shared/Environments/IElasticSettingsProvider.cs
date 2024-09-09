namespace Onion.CleanArchitecture.Net.Infrastructure.Shared.Environments
{
    public interface IElasticSettingsProvider
    {
        string GetCloudId();
        string GetApiKey();
    }
}
