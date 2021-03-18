using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceMaker.Migrations
{
    public partial class addInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "No",
                table: "PurchaseOrders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    To = table.Column<int>(type: "int", nullable: false),
                    DiscountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountAmount = table.Column<double>(type: "float", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceDue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseOrderID = table.Column<int>(type: "int", nullable: false),
                    LanguageID = table.Column<int>(type: "int", nullable: false),
                    CurrencyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Invoices_Companies_To",
                        column: x => x.To,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Currencies_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "Currencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Languages_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Languages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_PurchaseOrders_PurchaseOrderID",
                        column: x => x.PurchaseOrderID,
                        principalTable: "PurchaseOrders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CurrencyID",
                table: "Invoices",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_LanguageID",
                table: "Invoices",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PurchaseOrderID",
                table: "Invoices",
                column: "PurchaseOrderID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_To",
                table: "Invoices",
                column: "To");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.AlterColumn<int>(
                name: "No",
                table: "PurchaseOrders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
