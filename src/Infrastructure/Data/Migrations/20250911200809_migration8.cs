using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class migration8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BankAccountId",
                table: "transactions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_transactions_BankAccountId",
                table: "transactions",
                column: "BankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_bankAccounts_BankAccountId",
                table: "transactions",
                column: "BankAccountId",
                principalTable: "bankAccounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_bankAccounts_BankAccountId",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_transactions_BankAccountId",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "BankAccountId",
                table: "transactions");
        }
    }
}
