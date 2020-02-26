using Microsoft.EntityFrameworkCore.Migrations;

namespace CST.Demo.Ticketing.Migrations
{
    public partial class Ticket_AddTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Tickets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Tickets");
        }
    }
}
