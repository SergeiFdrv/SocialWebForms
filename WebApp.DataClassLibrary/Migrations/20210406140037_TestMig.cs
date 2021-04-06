using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.DataClassLibrary.Migrations
{
    public partial class TestMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hashtags",
                columns: table => new
                {
                    HashtagID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hashtags", x => x.HashtagID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserLogin = table.Column<string>(maxLength: 50, nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    UserPass = table.Column<string>(nullable: false),
                    UserRole = table.Column<string>(nullable: false),
                    UserEMail = table.Column<string>(maxLength: 50, nullable: false),
                    UserWebsite = table.Column<string>(nullable: true),
                    UserRegisteredUTC = table.Column<DateTime>(nullable: false),
                    UserLastLoginUTC = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostAuthorID = table.Column<int>(nullable: true),
                    PostDateUTC = table.Column<DateTime>(nullable: false),
                    PostEditedUTC = table.Column<DateTime>(nullable: false),
                    PostCategoryID = table.Column<int>(nullable: true),
                    PostContent = table.Column<string>(nullable: false),
                    PostRP = table.Column<int>(nullable: false),
                    PostTitle = table.Column<string>(maxLength: 255, nullable: false),
                    PostApprovement = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_Posts_Users_PostAuthorID",
                        column: x => x.PostAuthorID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentPostID = table.Column<int>(nullable: false),
                    CommentAuthorID = table.Column<int>(nullable: true),
                    CommentContent = table.Column<string>(nullable: false),
                    CommentRP = table.Column<int>(nullable: false),
                    CommentPostedUTC = table.Column<DateTime>(nullable: false),
                    CommentEditedUTC = table.Column<DateTime>(nullable: false),
                    CommentParentID = table.Column<int>(nullable: true),
                    CommentApprovement = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_Users_CommentAuthorID",
                        column: x => x.CommentAuthorID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_CommentParentID",
                        column: x => x.CommentParentID,
                        principalTable: "Comments",
                        principalColumn: "CommentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_CommentPostID",
                        column: x => x.CommentPostID,
                        principalTable: "Posts",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTagPairs",
                columns: table => new
                {
                    PostTagPairID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostID = table.Column<int>(nullable: false),
                    HashtagID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTagPairs", x => x.PostTagPairID);
                    table.ForeignKey(
                        name: "FK_PostTagPairs_Hashtags_HashtagID",
                        column: x => x.HashtagID,
                        principalTable: "Hashtags",
                        principalColumn: "HashtagID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTagPairs_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentAuthorID",
                table: "Comments",
                column: "CommentAuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentParentID",
                table: "Comments",
                column: "CommentParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentPostID",
                table: "Comments",
                column: "CommentPostID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostAuthorID",
                table: "Posts",
                column: "PostAuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostID_PostTitle",
                table: "Posts",
                columns: new[] { "PostID", "PostTitle" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostTagPairs_HashtagID",
                table: "PostTagPairs",
                column: "HashtagID");

            migrationBuilder.CreateIndex(
                name: "IX_PostTagPairs_PostID",
                table: "PostTagPairs",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_PostTagPairs_PostTagPairID",
                table: "PostTagPairs",
                column: "PostTagPairID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserEMail",
                table: "Users",
                column: "UserEMail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserLogin",
                table: "Users",
                column: "UserLogin",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PostTagPairs");

            migrationBuilder.DropTable(
                name: "Hashtags");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
