using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceMaker.Migrations
{
    public partial class fixForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Invoices_PurchaseOrderID",
                table: "Invoices");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PurchaseOrderID",
                table: "Invoices",
                column: "PurchaseOrderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Invoices_PurchaseOrderID",
                table: "Invoices");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PurchaseOrderID",
                table: "Invoices",
                column: "PurchaseOrderID",
                unique: true);
        }
    }
}
