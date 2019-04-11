using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeBilibili.Migrations.UserAndVideoDb
{
    public partial class UserAndVideoDb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fans",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Follows",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fans",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Follows",
                table: "Users");
        }
    }
}
