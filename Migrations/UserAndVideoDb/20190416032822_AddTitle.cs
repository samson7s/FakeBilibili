using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeBilibili.Migrations.UserAndVideoDb
{
    public partial class AddTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Videos",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Videos",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Videos");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Videos",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
