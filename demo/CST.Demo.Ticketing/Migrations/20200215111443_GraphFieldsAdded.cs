using Microsoft.EntityFrameworkCore.Migrations;

namespace CST.Demo.Ticketing.Migrations
{
    public partial class GraphFieldsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Graph",
                table: "TicketingVertex",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Graph",
                table: "TicketingEdge",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Graph",
                table: "TicketingVertex");

            migrationBuilder.DropColumn(
                name: "Graph",
                table: "TicketingEdge");
        }
    }
}
