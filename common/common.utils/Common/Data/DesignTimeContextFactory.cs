using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace CST.Common.Utils.Common.Data
{
    public interface ISelfFactory<TContext> where TContext : DbContext
    {
        TContext Create(DbContextOptions<TContext> options);
    }

    public class DesignTimeContextFactory<TContext> : IDesignTimeDbContextFactory<TContext>
        where TContext : DbContext, ISelfFactory<TContext>, new()
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

        public TContext CreateDbContext(string[] args)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                InitialCatalog = InitialCatalog,
                DataSource = DataSource
            };
            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            optionsBuilder.UseSqlServer(connectionStringBuilder.ConnectionString);
            return new TContext().Create(optionsBuilder.Options);
        }
    }
}