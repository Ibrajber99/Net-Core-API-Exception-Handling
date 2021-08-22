using Microsoft.EntityFrameworkCore.Migrations;

namespace NET_Core_API_Exception_Handling.Persistance.Migrations
{
    public partial class InitDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MartialStatus",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MartialStatus",
                table: "Persons",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
