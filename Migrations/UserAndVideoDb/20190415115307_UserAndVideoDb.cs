using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeBilibili.Migrations.UserAndVideoDb
{
    public partial class UserAndVideoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    AvatarType = table.Column<string>(nullable: true),
                    AvatarThumbnail = table.Column<byte[]>(nullable: true),
                    Follows = table.Column<string>(nullable: true),
                    Fans = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorId = table.Column<int>(nullable: false),
                    FileLocation = table.Column<string>(nullable: false),
                    Thumbnail = table.Column<byte[]>(nullable: true),
                    ThumbnailType = table.Column<string>(nullable: true),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    PublishDateTime = table.Column<DateTime>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    Tag = table.Column<string>(nullable: true),
                    VideoView = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videos_AuthorId",
                table: "Videos",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
