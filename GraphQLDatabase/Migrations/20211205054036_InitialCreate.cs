using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GraphQLDatabase.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Released = table.Column<string>(type: "text", nullable: true),
                    Actors = table.Column<string>(type: "text", nullable: true),
                    Writers = table.Column<string>(type: "text", nullable: true),
                    Director = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Actors", "Director", "Name", "Released", "Writers" },
                values: new object[,]
                {
                    { 1L, "Martin Corsezi", "Joel Shoemacker", "Intestellar", "2021-02-03", "Some Writer" },
                    { 2L, "Keanu Reeves", "Lana Wachowski", "The Matrix", "2021-02-03", "Some Writer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
