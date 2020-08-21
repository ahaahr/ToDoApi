using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoApi.Migrations.ToDoItemToUserRelation
{
    public partial class InitialMigrationUserToDoItemRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    ToDoItemID = table.Column<string>(nullable: false),
                    UserID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Relations");
        }
    }
}
