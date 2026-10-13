using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class Cascades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issue_Student_StudentID",
                table: "Issue");

            migrationBuilder.DropForeignKey(
                name: "FK_Issue_Subject_SubjectID",
                table: "Issue");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemIssue_Stock_StockID",
                table: "ItemIssue");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Item_ItemID",
                table: "Stock");

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_Student_StudentID",
                table: "Issue",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_Subject_SubjectID",
                table: "Issue",
                column: "SubjectID",
                principalTable: "Subject",
                principalColumn: "SubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemIssue_Stock_StockID",
                table: "ItemIssue",
                column: "StockID",
                principalTable: "Stock",
                principalColumn: "StockID");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Item_ItemID",
                table: "Stock",
                column: "ItemID",
                principalTable: "Item",
                principalColumn: "ItemID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issue_Student_StudentID",
                table: "Issue");

            migrationBuilder.DropForeignKey(
                name: "FK_Issue_Subject_SubjectID",
                table: "Issue");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemIssue_Stock_StockID",
                table: "ItemIssue");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Item_ItemID",
                table: "Stock");

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_Student_StudentID",
                table: "Issue",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_Subject_SubjectID",
                table: "Issue",
                column: "SubjectID",
                principalTable: "Subject",
                principalColumn: "SubjectID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemIssue_Stock_StockID",
                table: "ItemIssue",
                column: "StockID",
                principalTable: "Stock",
                principalColumn: "StockID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Item_ItemID",
                table: "Stock",
                column: "ItemID",
                principalTable: "Item",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
