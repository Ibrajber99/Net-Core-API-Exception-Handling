using Microsoft.EntityFrameworkCore.Migrations;

namespace NET_Core_API_Exception_Handling.Persistance.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    MartialStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "ID", "EmailAddress", "FirstName", "LastName", "MartialStatus" },
                values: new object[] { 1, "jb@gmail.com", "Ibra", "Jaber", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
