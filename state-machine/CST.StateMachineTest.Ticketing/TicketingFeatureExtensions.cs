using AutoMapper;
using CST.Common.Utils.StateMachineFeature;
using CST.StateMachineTest.Data;
using CST.StateMachineTest.Ticketing.Data;
using CST.StateMachineTest.Ticketing.Repositories;
using CST.StateMachineTest.Ticketing.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CST.StateMachineTest.Ticketing
{
    public static class TicketingFeatureExtensions 
    {
        public static IServiceCollection ConfigureTicketingFeature(this IServiceCollection services)
        {
            services.AddDbContext<StateMachineContext>(builder =>
            {
                var connectionStringBuilder = new SqlConnectionStringBuilder()
                {
                    InitialCatalog = "StateMachine",
                    DataSource = "(localdb)\\MSSQLLocalDB",
                    IntegratedSecurity = true,
                    MultipleActiveResultSets = true
                };
                builder.UseSqlServer(connectionStringBuilder.ConnectionString);
            });
            services.AddScoped<TicketingService>();
            services.AddScoped<TicketRepository>();
            services.AddStateMachineFeature(builder =>
            {
                builder
                    .WithKeyType<int>()
                    .WithGraphEnumType<GraphEnum>()
                    .WithVertexEnumType<TicketingEnum>()
                    .WithSubjectType<Ticket>()
                    .WithRepositoryType<TicketingRepository>()
                    .WithStateMachineService<TicketingStateMachineService>()
                    .Build();
            });
            services.AddAutoMapper(typeof(TicketingFeatureExtensions).Assembly);

            return services;
        }

        public static IApplicationBuilder UseTicketingFeature(this IApplicationBuilder app)
        {
            return app;
        }
    }
}