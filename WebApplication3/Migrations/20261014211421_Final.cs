using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemIssue_Issue_IssueID",
                table: "ItemIssue");

            migrationBuilder.DropIndex(
                name: "IX_ItemIssue_StockID",
                table: "ItemIssue");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Email",
                table: "Student",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stock_StockTag",
                table: "Stock",
                column: "StockTag",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemIssue_StockID",
                table: "ItemIssue",
                column: "StockID",
                unique: true,
                filter: "[DateReturned] IS NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemIssue_Issue_IssueID",
                table: "ItemIssue",
                column: "IssueID",
                principalTable: "Issue",
                principalColumn: "IssueID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemIssue_Issue_IssueID",
                table: "ItemIssue");

            migrationBuilder.DropIndex(
                name: "IX_Student_Email",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Stock_StockTag",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_ItemIssue_StockID",
                table: "ItemIssue");

            migrationBuilder.CreateIndex(
                name: "IX_ItemIssue_StockID",
                table: "ItemIssue",
                column: "StockID");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemIssue_Issue_IssueID",
                table: "ItemIssue",
                column: "IssueID",
                principalTable: "Issue",
                principalColumn: "IssueID");
        }
    }
}
