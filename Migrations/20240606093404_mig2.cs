using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakaleProject.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleDetails",
                columns: table => new
                {
                    MakeleID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Desc = table.Column<string>(type: "TEXT", nullable: false),
                    ArContent = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CommentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleDetails", x => x.MakeleID);
                });

            migrationBuilder.CreateTable(
                name: "ArticleDetailsUser",
                columns: table => new
                {
                    ArticleDetailsMakeleID = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleDetailsUser", x => new { x.ArticleDetailsMakeleID, x.UsersID });
                    table.ForeignKey(
                        name: "FK_ArticleDetailsUser_ArticleDetails_ArticleDetailsMakeleID",
                        column: x => x.ArticleDetailsMakeleID,
                        principalTable: "ArticleDetails",
                        principalColumn: "MakeleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleDetailsUser_Users_UsersID",
                        column: x => x.UsersID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArticleID = table.Column<int>(type: "INTEGER", nullable: false),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    ArticleDetailsMakeleID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_ArticleDetails_ArticleDetailsMakeleID",
                        column: x => x.ArticleDetailsMakeleID,
                        principalTable: "ArticleDetails",
                        principalColumn: "MakeleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleDetailsUser_UsersID",
                table: "ArticleDetailsUser",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleDetailsMakeleID",
                table: "Comments",
                column: "ArticleDetailsMakeleID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID",
                table: "Comments",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleDetailsUser");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ArticleDetails");
        }
    }
}
