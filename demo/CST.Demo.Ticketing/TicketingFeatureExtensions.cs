﻿using AutoMapper;
using CST.Common.Utils.StateMachineFeature;
using CST.Demo.Ticketing.Controllers;
using CST.Demo.Data;
using CST.Demo.Data.Models.Ticketing;
using CST.Demo.Ticketing.Repositories;
using CST.Demo.Ticketing.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using System;

namespace CST.Demo.Ticketing
{
    public static class TicketingFeatureExtensions
    {
        private const string CorsPolicyName = "TicketingFrontend";
        private const string InitialCatalogEnvKey = "Ticketing_InitialCatalog";
        private const string DataSourceEnvKey = "Ticketing_DataSource";
        private static (string catalog, string dataSource) AssertEnvironmentVariables()
        {
            var catalog = Environment.GetEnvironmentVariable(InitialCatalogEnvKey);
            var ds = Environment.GetEnvironmentVariable(DataSourceEnvKey);
            if (string.IsNullOrEmpty(catalog))
                throw new Exception($"{InitialCatalogEnvKey} has to be set");
            if (string.IsNullOrEmpty(ds))
                throw new Exception($"{DataSourceEnvKey} has to be set");

            return (catalog, ds);
        }

        public static IServiceCollection ConfigureTicketingFeature(
            this IServiceCollection services)
        {
            var (catalog, ds) = AssertEnvironmentVariables();
            services.AddDbContext<DemoContext>(builder =>
            {
                var connectionStringBuilder = new SqlConnectionStringBuilder()
                {
                    InitialCatalog = catalog,
                    DataSource = ds,
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