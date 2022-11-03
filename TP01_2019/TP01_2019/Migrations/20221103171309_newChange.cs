using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP01_2019.Migrations
{
    public partial class newChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                 name: "Piloto",
                 columns: table => new
                 {
                     Id = table.Column<int>(type: "int", nullable: false)
                         .Annotation("SqlServer:Identity", "1, 1"),
                     Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                     Pontos = table.Column<int>(type: "int", nullable: false),
                     CarroId = table.Column<int>(type: "int", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_Piloto", x => x.Id);
                     table.ForeignKey(
                         name: "FK_Piloto_Carro_CarroId",
                         column: x => x.CarroId,
                         principalTable: "Carro",
                         principalColumn: "Id");
                 });

            migrationBuilder.CreateIndex(
                name: "IX_Piloto_CarroId",
                table: "Piloto",
                column: "CarroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Piloto");
        }
    }
}
