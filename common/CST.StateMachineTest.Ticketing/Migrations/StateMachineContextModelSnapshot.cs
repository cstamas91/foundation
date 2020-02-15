﻿// <auto-generated />

using CST.StateMachineTest.Ticketing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CST.StateMachineTest.Ticketing.Migrations
{
    [DbContext(typeof(StateMachineContext))]
    partial class StateMachineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CST.Common.Utils.StateMachineFeature.BaseClasses.Edge<int, CST.StateMachineTest.Data.GraphEnum, CST.StateMachineTest.Data.TicketingEnum>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Graph")
                        .HasColumnType("int");

                    b.Property<int?>("HeadId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TailId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HeadId");

                    b.HasIndex("TailId");

                    b.ToTable("TicketingEdge");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Graph = 0,
                            HeadId = 3,
                            Name = "Claim for research",
                            TailId = 1
                        },
                        new
                        {
                            Id = 2,
                            Graph = 0,
                            HeadId = 2,
                            Name = "Start fix",
                            TailId = 3
                        },
                        new
                        {
                            Id = 3,
                            Graph = 0,
                            HeadId = 4,
                            Name = "Resolve",
                            TailId = 2
                        },
                        new
                        {
                            Id = 4,
                            Graph = 0,
                            HeadId = 5,
                            Name = "Close",
                            TailId = 1
                        },
                        new
                        {
                            Id = 5,
                            Graph = 0,
                            HeadId = 5,
                            Name = "Close",
                            TailId = 2
                        },
                        new
                        {
                            Id = 6,
                            Graph = 0,
                            HeadId = 5,
                            Name = "Close",
                            TailId = 3
                        });
                });

            modelBuilder.Entity("CST.Common.Utils.StateMachineFeature.BaseClasses.StateMachineSubjectMoment<int, CST.StateMachineTest.Data.GraphEnum, CST.StateMachineTest.Data.TicketingEnum, CST.StateMachineTest.Data.Ticket>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int?>("VertexId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId")
                        .IsUnique();

                    b.HasIndex("VertexId");

                    b.ToTable("TicketingHistory");
                });

            modelBuilder.Entity("CST.Common.Utils.StateMachineFeature.BaseClasses.Vertex<int, CST.StateMachineTest.Data.GraphEnum, CST.StateMachineTest.Data.TicketingEnum>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Graph")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VertexEnum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TicketingVertex");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Graph = 0,
                            Name = "Open",
                            VertexEnum = 0
                        },
                        new
                        {
                            Id = 2,
                            Graph = 0,
                            Name = "Development",
                            VertexEnum = 2
                        },
                        new
                        {
                            Id = 3,
                            Graph = 0,
                            Name = "Research",
                            VertexEnum = 1
                        },
                        new
                        {
                            Id = 4,
                            Graph = 0,
                            Name = "Solved",
                            VertexEnum = 3
                        },
                        new
                        {
                            Id = 5,
                            Graph = 0,
                            Name = "ClosedWithNoFix",
                            VertexEnum = 4
                        });
                });

            modelBuilder.Entity("CST.StateMachineTest.Data.Commit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Hash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("Commits");
                });

            modelBuilder.Entity("CST.StateMachineTest.Data.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("CST.Common.Utils.StateMachineFeature.BaseClasses.Edge<int, CST.StateMachineTest.Data.GraphEnum, CST.StateMachineTest.Data.TicketingEnum>", b =>
                {
                    b.HasOne("CST.Common.Utils.StateMachineFeature.BaseClasses.Vertex<int, CST.StateMachineTest.Data.GraphEnum, CST.StateMachineTest.Data.TicketingEnum>", "Head")
                        .WithMany("InEdges")
                        .HasForeignKey("HeadId");

                    b.HasOne("CST.Common.Utils.StateMachineFeature.BaseClasses.Vertex<int, CST.StateMachineTest.Data.GraphEnum, CST.StateMachineTest.Data.TicketingEnum>", "Tail")
                        .WithMany("OutEdges")
                        .HasForeignKey("TailId");
                });

            modelBuilder.Entity("CST.Common.Utils.StateMachineFeature.BaseClasses.StateMachineSubjectMoment<int, CST.StateMachineTest.Data.GraphEnum, CST.StateMachineTest.Data.TicketingEnum, CST.StateMachineTest.Data.Ticket>", b =>
                {
                    b.HasOne("CST.StateMachineTest.Data.Ticket", "Subject")
                        .WithOne("CurrentSubjectState")
                        .HasForeignKey("CST.Common.Utils.StateMachineFeature.BaseClasses.StateMachineSubjectMoment<int, CST.StateMachineTest.Data.GraphEnum, CST.StateMachineTest.Data.TicketingEnum, CST.StateMachineTest.Data.Ticket>", "SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CST.Common.Utils.StateMachineFeature.BaseClasses.Vertex<int, CST.StateMachineTest.Data.GraphEnum, CST.StateMachineTest.Data.TicketingEnum>", "Vertex")
                        .WithMany()
                        .HasForeignKey("VertexId");
                });

            modelBuilder.Entity("CST.StateMachineTest.Data.Commit", b =>
                {
                    b.HasOne("CST.StateMachineTest.Data.Ticket", null)
                        .WithMany("RelatedCommits")
                        .HasForeignKey("TicketId");
                });
#pragma warning restore 612, 618
        }
    }
}
