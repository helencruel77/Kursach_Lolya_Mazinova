using Microsoft.EntityFrameworkCore.Migrations;

namespace AbstractUniversityImplementation.Migrations
{
    public partial class Place : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Places",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Places");
        }
    }
}
