﻿namespace Onion.CleanArchitecture.Net.Infrastructure.Shared.Environments
{
    public interface IDatabaseSettingsProvider
    {
        string GetPostgresConnectionString();
        string GetMySQLConnectionString();
        string GetSQLServerConnectionString();
    }
}
