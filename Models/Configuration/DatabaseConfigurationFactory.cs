namespace Models.Configuration
{
    public enum DatabaseConfigurators
    {
        SQLITE,
        POSTGRESQL,
        SQLSERVER,
    };

    public static class DatabaseConfiguratorFactory
    {
        public static IDatabaseConfigurator Create(DatabaseConfigurators configurator)
        {
            return configurator switch
            {
                DatabaseConfigurators.SQLITE => new SqliteConfigurator(),
                DatabaseConfigurators.POSTGRESQL => new PostgreSqlConfigurator(),
                DatabaseConfigurators.SQLSERVER => new SqlServerConfigurator(),
                _ => throw new InvalidOperationException(
                    $"Unsupported DB configurator: {configurator}"
                ),
            };
        }
    }
}
