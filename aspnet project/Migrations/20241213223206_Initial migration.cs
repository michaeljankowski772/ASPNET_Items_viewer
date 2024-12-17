using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnet_project.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlotId = table.Column<int>(type: "int", nullable: false),
                    Armor = table.Column<int>(type: "int", nullable: false),
                    PhysicalReductionPercent = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemSetItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ItemSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSetItems", x => new { x.ItemId, x.ItemSetId });
                    table.ForeignKey(
                        name: "FK_ItemSetItems_ItemSets_ItemSetId",
                        column: x => x.ItemSetId,
                        principalTable: "ItemSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemSetItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ItemSets",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Golden set" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Armor", "ImageURL", "Name", "PhysicalReductionPercent", "SlotId" },
                values: new object[] { 1, 12, "https://static.wikia.nocookie.net/tibia/images/d/d0/Golden_Armor.gif/revision/latest?cb=20050613134413&path-prefix=en&format=original", "Golden Armor", 0, 0 });

            migrationBuilder.InsertData(
                table: "ItemSetItems",
                columns: new[] { "ItemId", "ItemSetId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ItemSetItems_ItemSetId",
                table: "ItemSetItems",
                column: "ItemSetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemSetItems");

            migrationBuilder.DropTable(
                name: "ItemSets");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
