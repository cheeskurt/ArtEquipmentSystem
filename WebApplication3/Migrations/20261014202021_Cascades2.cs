using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class Cascades2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Subject_SubjectID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemIssue_Issue_IssueID",
                table: "ItemIssue");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SubjectID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SubjectID",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemIssue_Issue_IssueID",
                table: "ItemIssue",
                column: "IssueID",
                principalTable: "Issue",
                principalColumn: "IssueID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemIssue_Issue_IssueID",
                table: "ItemIssue");

            migrationBuilder.AddColumn<int>(
                name: "SubjectID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SubjectID",
                table: "AspNetUsers",
                column: "SubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Subject_SubjectID",
                table: "AspNetUsers",
                column: "SubjectID",
                principalTable: "Subject",
                principalColumn: "SubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemIssue_Issue_IssueID",
                table: "ItemIssue",
                column: "IssueID",
                principalTable: "Issue",
                principalColumn: "IssueID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
