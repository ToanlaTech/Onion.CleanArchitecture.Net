namespace Onion.CleanArchitecture.Net.CoreWorker.Interfaces
{
    public interface IDatabaseSettingsProvider
    {
        string GetPostgresConnectionString();
        string GetMySQLConnectionString();
        string GetSQLServerConnectionString();
    }
}
