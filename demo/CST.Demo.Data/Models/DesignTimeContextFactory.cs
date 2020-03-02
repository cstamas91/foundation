using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace CST.Demo.Data.Models
{
    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<DemoContext>
    {
        const string InitialCatalogEnvVariableName = "DesignTime_InitialCatalog";
        const string DataSourceEnvVariableName = "DesignTime_DataSource";
        private readonly string InitialCatalog = string.Empty;
        private readonly string DataSource = string.Empty;
        public DesignTimeContextFactory()
        {
            InitialCatalog = Environment.GetEnvironmentVariable(InitialCatalogEnvVariableName);
            DataSource = Environment.GetEnvironmentVariable(DataSourceEnvVariableName);
            if (string.IsNullOrEmpty(InitialCatalog))
                throw new Exception($"{InitialCatalogEnvVariableName} env has to be set.");
            if (string.IsNullOrEmpty(DataSource))
                throw new Exception($"{DataSourceEnvVariableName} env has to be set.");
        }
        public DemoContext CreateDbContext(string[] args)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                InitialCatalog = InitialCatalog,
                DataSource = DataSource
            };
            var optionsBuilder = new DbContextOptionsBuilder<DemoContext>();
            optionsBuilder.UseSqlServer(connectionStringBuilder.ConnectionString);
            return new DemoContext(optionsBuilder.Options);
        }
    }
}
