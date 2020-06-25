using Microsoft.EntityFrameworkCore.Migrations;

namespace IMS_CURD.Migrations
{
    public partial class EdmxInventoryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryMaster",
                columns: table => new
                {
                    InventoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(nullable: false),
                    StockQty = table.Column<int>(nullable: false),
                    ReorderQty = table.Column<int>(nullable: false),
                    PriorityStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryMaster", x => x.InventoryID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryMaster");
        }
    }
}
