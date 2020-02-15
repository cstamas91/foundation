using System.Collections.Generic;
using CST.Common.Utils.StateMachineFeature.BaseClasses;
using CST.StateMachineTest.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

// ReSharper disable StringLiteralTypo

namespace CST.StateMachineTest.Ticketing.Data
{
    using TTicketingHistory = StateMachineSubjectMoment<int, GraphEnum, TicketingEnum, Ticket>;
    using TicketVertex = Vertex<int, GraphEnum, TicketingEnum>;
    using TicketEdge = Edge<int, GraphEnum, TicketingEnum>;

    public class DesignTimeHelper : IDesignTimeDbContextFactory<StateMachineContext> 
    {
        public StateMachineContext CreateDbContext(string[] args)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder()
            {
                InitialCatalog = "StateMachine",
                DataSource = "(localdb)\\MSSQLLocalDB",
                IntegratedSecurity = true,
                MultipleActiveResultSets = true
            };
            var optionsBuilder = new DbContextOptionsBuilder<StateMachineContext>();
            optionsBuilder.UseSqlServer(connectionStringBuilder.ConnectionString);
            return new StateMachineContext(optionsBuilder.Options);
        }
    }
    
    public class StateMachineContext : DbContext
    {
        public StateMachineContext(DbContextOptions<StateMachineContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TTicketingHistory>()
                .HasOne(moment => moment.Subject)
                .WithOne(ticket => ticket.CurrentSubjectState)
                .HasForeignKey<TTicketingHistory>(moment => moment.SubjectId);
            modelBuilder.Entity<TTicketingHistory>()
                .HasOne(moment => moment.Vertex);
            modelBuilder.Entity<TicketVertex>()
                .HasData(new List<TicketVertex>
                {
                    new TicketVertex
                    {
                        Id = 1,
                        VertexEnum = TicketingEnum.Open,
                        Name = nameof(TicketingEnum.Open),
                        Graph = GraphEnum.Ticketing
                    },
                    new TicketVertex
                    {
                        Id = 2,
                        VertexEnum = TicketingEnum.Development,
                        Name = nameof(TicketingEnum.Development),
                        Graph = GraphEnum.Ticketing
                    },
                    new TicketVertex
                    {
                        Id = 3,
                        VertexEnum = TicketingEnum.Research,
                        Name = nameof(TicketingEnum.Research),
                        Graph = GraphEnum.Ticketing
                    },
                    new TicketVertex
                    {
                        Id = 4,
                        VertexEnum = TicketingEnum.Solved,
                        Name = nameof(TicketingEnum.Solved),
                        Graph = GraphEnum.Ticketing
                    },
                    new TicketVertex
                    {
                        Id = 5,
                        VertexEnum = TicketingEnum.ClosedWithNoFix,
                        Name = nameof(TicketingEnum.ClosedWithNoFix),
                        Graph = GraphEnum.Ticketing
                    }
                });
            
            modelBuilder.Entity<TicketEdge>()
                .HasOne(edge => edge.Head)
                .WithMany(vertex => vertex.InEdges);
            modelBuilder.Entity<TicketEdge>()
                .HasOne(edge => edge.Tail)
                .WithMany(vertex => vertex.OutEdges);

            modelBuilder.Entity<TicketEdge>()
                .HasData(new List<object>
                {
                    new
                    {
                        Id = 1,
                        TailId = 1,
                        HeadId = 3,
                        Name = "Claim for research",
                        Graph = GraphEnum.Ticketing
                    },
                    new
                    {
                        Id = 2,
                        TailId = 3,
                        HeadId = 2,
                        Name = "Start fix",
                        Graph = GraphEnum.Ticketing
                    },
                    new
                    {
                        Id = 3,
                        TailId = 2,
                        HeadId = 4,
                        Name = "Resolve",
                        Graph = GraphEnum.Ticketing
                    },
                    new
                    {
                        Id = 4,
                        TailId = 1,
                        HeadId = 5,
                        Name = "Close",
                        Graph = GraphEnum.Ticketing
                    },
                    new
                    {
                        Id = 5,
                        TailId = 2,
                        HeadId = 5,
                        Name = "Close",
                        Graph = GraphEnum.Ticketing
                    },
                    new
                    {
                        Id = 6,
                        TailId = 3,
                        HeadId = 5,
                        Name = "Close",
                        Graph = GraphEnum.Ticketing
                    }
                });
        }

        public virtual DbSet<Vertex<int, GraphEnum, TicketingEnum>> TicketingVertex { get; set; }
        public virtual DbSet<Edge<int, GraphEnum, TicketingEnum>> TicketingEdge { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TTicketingHistory> TicketingHistory { get; set; }
        public virtual DbSet<Commit> Commits { get; set; }
    }
}