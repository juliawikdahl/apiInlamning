using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InlamningAPI.Migrations
{
    public partial class tagitbortpasswordentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Passwords_Passwordid",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Passwords");

            migrationBuilder.DropIndex(
                name: "IX_Customers_Passwordid",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Passwordid",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customers",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "Passwordid",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Passwords",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passwords", x => x.id);
                });

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
    }
}
