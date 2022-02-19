using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InlamningAPI.Migrations
{
    public partial class Lagttilllösenordicustomerentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Passwords_PasswordEntityid",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_PasswordEntityid",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PasswordEntityid",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "PasswordId",
                table: "Customers",
                newName: "Passwordid");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Passwordid",
                table: "Customers",
                column: "Passwordid");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Passwords_Passwordid",
                table: "Customers",
                column: "Passwordid",
                principalTable: "Passwords",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Passwords_Passwordid",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_Passwordid",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Passwordid",
                table: "Customers",
                newName: "PasswordId");

            migrationBuilder.AddColumn<int>(
                name: "PasswordEntityid",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PasswordEntityid",
                table: "Customers",
                column: "PasswordEntityid");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Passwords_PasswordEntityid",
                table: "Customers",
                column: "PasswordEntityid",
                principalTable: "Passwords",
                principalColumn: "id");
        }
    }
}
