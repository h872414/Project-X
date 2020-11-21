using Microsoft.EntityFrameworkCore.Migrations;

namespace DicomLoaderWeb.Migrations
{
    public partial class StatusNameAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusName",
                table: "Statuses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusName",
                table: "Statuses");
        }
    }
}
