using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class TPH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSupplier_Suppliers_SuppliersSupplierId",
                table: "ProductSupplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "People");

            migrationBuilder.RenameColumn(
                name: "SuppliersSupplierId",
                table: "ProductSupplier",
                newName: "SuppliersPersonID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSupplier_SuppliersSupplierId",
                table: "ProductSupplier",
                newName: "IX_ProductSupplier_SuppliersPersonID");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "People",
                newName: "PersonID");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "People",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CType",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "People",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSupplier_People_SuppliersPersonID",
                table: "ProductSupplier",
                column: "SuppliersPersonID",
                principalTable: "People",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSupplier_People_SuppliersPersonID",
                table: "ProductSupplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CType",
                table: "People");

            migrationBuilder.DropColumn(
                name: "City",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "Suppliers");

            migrationBuilder.RenameColumn(
                name: "SuppliersPersonID",
                table: "ProductSupplier",
                newName: "SuppliersSupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSupplier_SuppliersPersonID",
                table: "ProductSupplier",
                newName: "IX_ProductSupplier_SuppliersSupplierId");

            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "Suppliers",
                newName: "SupplierId");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Suppliers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSupplier_Suppliers_SuppliersSupplierId",
                table: "ProductSupplier",
                column: "SuppliersSupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
