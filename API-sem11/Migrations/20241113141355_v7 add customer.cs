using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_sem11.Migrations
{
    /// <inheritdoc />
    public partial class v7addcustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Details_Customers_CustomerID",
                table: "Details");

            migrationBuilder.DropIndex(
                name: "IX_Details_CustomerID",
                table: "Details");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Details");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Details",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Details_CustomerID",
                table: "Details",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Customers_CustomerID",
                table: "Details",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID");
        }
    }
}
