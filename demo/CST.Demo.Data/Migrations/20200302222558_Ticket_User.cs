﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace CST.Demo.Data.Migrations
{
    public partial class Ticket_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Users",
                schema: "identity",
                newName: "Users");

            migrationBuilder.CreateTable(
                name: "TicketingVertex",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Graph = table.Column<int>(nullable: false),
                    VertexEnum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketingVertex", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketingEdge",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    TailId = table.Column<int>(nullable: true),
                    HeadId = table.Column<int>(nullable: true),
                    Graph = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketingEdge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketingEdge_TicketingVertex_HeadId",
                        column: x => x.HeadId,
                        principalTable: "TicketingVertex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketingEdge_TicketingVertex_TailId",
                        column: x => x.TailId,
                        principalTable: "TicketingVertex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Commits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hash = table.Column<string>(nullable: true),
                    TicketId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commits_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketingHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VertexId = table.Column<int>(nullable: true),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketingHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketingHistory_Tickets_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketingHistory_TicketingVertex_VertexId",
                        column: x => x.VertexId,
                        principalTable: "TicketingVertex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TicketingVertex",
                columns: new[] { "Id", "Graph", "Name", "VertexEnum" },
                values: new object[,]
                {
                    { 1, 0, "Open", 0 },
                    { 2, 0, "Development", 2 },
                    { 3, 0, "Research", 1 },
                    { 4, 0, "Solved", 3 },
                    { 5, 0, "ClosedWithNoFix", 4 }
                });

            migrationBuilder.InsertData(
                table: "TicketingEdge",
                columns: new[] { "Id", "Graph", "HeadId", "Name", "TailId" },
                values: new object[,]
                {
                    { 1, 0, 3, "Claim for research", 1 },
                    { 2, 0, 2, "Start fix", 3 },
                    { 3, 0, 4, "Resolve", 2 },
                    { 4, 0, 5, "Close", 1 },
                    { 5, 0, 5, "Close", 2 },
                    { 6, 0, 5, "Close", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commits_TicketId",
                table: "Commits",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketingEdge_HeadId",
                table: "TicketingEdge",
                column: "HeadId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketingEdge_TailId",
                table: "TicketingEdge",
                column: "TailId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketingHistory_SubjectId",
                table: "TicketingHistory",
                column: "SubjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketingHistory_VertexId",
                table: "TicketingHistory",
                column: "VertexId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commits");

            migrationBuilder.DropTable(
                name: "TicketingEdge");

            migrationBuilder.DropTable(
                name: "TicketingHistory");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "TicketingVertex");

            migrationBuilder.EnsureSchema(
                name: "identity");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "identity");
        }
    }
}