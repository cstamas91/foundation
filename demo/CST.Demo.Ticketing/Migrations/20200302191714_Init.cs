using Microsoft.EntityFrameworkCore.Migrations;

namespace CST.Demo.Ticketing.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ticketing");

            migrationBuilder.CreateTable(
                name: "TicketingVertex",
                schema: "ticketing",
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
                schema: "ticketing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketingEdge",
                schema: "ticketing",
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
                        principalSchema: "ticketing",
                        principalTable: "TicketingVertex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketingEdge_TicketingVertex_TailId",
                        column: x => x.TailId,
                        principalSchema: "ticketing",
                        principalTable: "TicketingVertex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Commits",
                schema: "ticketing",
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
                        principalSchema: "ticketing",
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketingHistory",
                schema: "ticketing",
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
                        principalSchema: "ticketing",
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketingHistory_TicketingVertex_VertexId",
                        column: x => x.VertexId,
                        principalSchema: "ticketing",
                        principalTable: "TicketingVertex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "ticketing",
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
                schema: "ticketing",
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
                schema: "ticketing",
                table: "Commits",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketingEdge_HeadId",
                schema: "ticketing",
                table: "TicketingEdge",
                column: "HeadId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketingEdge_TailId",
                schema: "ticketing",
                table: "TicketingEdge",
                column: "TailId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketingHistory_SubjectId",
                schema: "ticketing",
                table: "TicketingHistory",
                column: "SubjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketingHistory_VertexId",
                schema: "ticketing",
                table: "TicketingHistory",
                column: "VertexId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commits",
                schema: "ticketing");

            migrationBuilder.DropTable(
                name: "TicketingEdge",
                schema: "ticketing");

            migrationBuilder.DropTable(
                name: "TicketingHistory",
                schema: "ticketing");

            migrationBuilder.DropTable(
                name: "Tickets",
                schema: "ticketing");

            migrationBuilder.DropTable(
                name: "TicketingVertex",
                schema: "ticketing");
        }
    }
}
