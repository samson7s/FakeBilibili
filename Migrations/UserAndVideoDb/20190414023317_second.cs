using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeBilibili.Migrations.UserAndVideoDb
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VideoType",
                table: "Videos",
                newName: "FileLocation");

            migrationBuilder.AddColumn<byte[]>(
                name: "Thumbnail",
                table: "Videos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailType",
                table: "Videos",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "AvatarThumbnail",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvatarType",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Thumbnail",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "ThumbnailType",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "AvatarThumbnail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AvatarType",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "FileLocation",
                table: "Videos",
                newName: "VideoType");
        }
    }
}
