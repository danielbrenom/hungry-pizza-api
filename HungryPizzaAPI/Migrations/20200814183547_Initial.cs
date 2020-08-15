using Microsoft.EntityFrameworkCore.Migrations;

namespace HungryPizzaAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tastes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tastes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tastes",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "3 Queijos", 50f },
                    { 2, "Frango com requeijão", 59.99f },
                    { 3, "Mussarela", 42.5f },
                    { 4, "Calabresa", 42.5f },
                    { 5, "Pepperoni", 55f },
                    { 6, "Portuguesa", 45f },
                    { 7, "Veggie", 59.99f }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Tastes");
        }
    }
}
