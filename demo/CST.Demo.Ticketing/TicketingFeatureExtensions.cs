using AutoMapper;
using CST.Common.Utils.StateMachineFeature;
using CST.Demo.Ticketing.Controllers;
using CST.Demo.Ticketing.Data;
using CST.Demo.Ticketing.Repositories;
using CST.Demo.Ticketing.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Internal;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace CST.Demo.Ticketing
{
    public static class TicketingFeatureExtensions
    {
        private const string CorsPolicyName = "TicketingFrontend";

        public static IServiceCollection ConfigureTicketingFeature(this IServiceCollection services)
        {
            services.AddDbContext<StateMachineContext>(builder =>
            {
                var connectionStringBuilder = new SqlConnectionStringBuilder()
                {
                    InitialCatalog = "StateMachine",
                    DataSource = @"(localdb)\MSSQLLocalDB",
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
                    .WithSubjectType<Ticket>(nameof(TicketingController).Replace("Controller", string.Empty))
                    .WithRepositoryType<TicketingRepository>()
                    .WithStateMachineService<TicketingStateMachineService>()
                    .Build();
            });
            services.AddAutoMapper(typeof(TicketingFeatureExtensions).Assembly);
            services.AddCors(options =>
            {
                options.AddPolicy(
                    CorsPolicyName,
                    ConfigureCorsPolicy);
            });

            return services;
        }

        private static void ConfigureCorsPolicy(CorsPolicyBuilder builder)
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .WithHeaders(HeaderNames.ContentType);
        }

        public static IApplicationBuilder UseTicketingFeature(this IApplicationBuilder app)
        {
            app.UseCors(CorsPolicyName);
            return app;
        }
    }
}