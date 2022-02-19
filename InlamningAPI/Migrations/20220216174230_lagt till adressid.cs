using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InlamningAPI.Migrations
{
    public partial class lagttilladressid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Customers");
        }
    }
}
