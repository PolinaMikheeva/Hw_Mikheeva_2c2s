using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonPokemonType_PokemonTypes_PokemonTypesId",
                table: "PokemonPokemonType");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonPokemonType_Pokemons_PokemonsId",
                table: "PokemonPokemonType");

            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Breedings_BreedingId",
                table: "Pokemons");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_BreedingId",
                table: "Pokemons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PokemonPokemonType",
                table: "PokemonPokemonType");

            migrationBuilder.DropColumn(
                name: "BreedingId",
                table: "Pokemons");

            migrationBuilder.RenameTable(
                name: "PokemonPokemonType",
                newName: "PokemonPokemonTypes");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonPokemonType_PokemonsId",
                table: "PokemonPokemonTypes",
                newName: "IX_PokemonPokemonTypes_PokemonsId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pokemons",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Breedings",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PokemonPokemonTypes",
                table: "PokemonPokemonTypes",
                columns: new[] { "PokemonTypesId", "PokemonsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Breedings_Pokemons_Id",
                table: "Breedings",
                column: "Id",
                principalTable: "Pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonPokemonTypes_PokemonTypes_PokemonTypesId",
                table: "PokemonPokemonTypes",
                column: "PokemonTypesId",
                principalTable: "PokemonTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonPokemonTypes_Pokemons_PokemonsId",
                table: "PokemonPokemonTypes",
                column: "PokemonsId",
                principalTable: "Pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breedings_Pokemons_Id",
                table: "Breedings");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonPokemonTypes_PokemonTypes_PokemonTypesId",
                table: "PokemonPokemonTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonPokemonTypes_Pokemons_PokemonsId",
                table: "PokemonPokemonTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PokemonPokemonTypes",
                table: "PokemonPokemonTypes");

            migrationBuilder.RenameTable(
                name: "PokemonPokemonTypes",
                newName: "PokemonPokemonType");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonPokemonTypes_PokemonsId",
                table: "PokemonPokemonType",
                newName: "IX_PokemonPokemonType_PokemonsId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pokemons",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "BreedingId",
                table: "Pokemons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Breedings",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PokemonPokemonType",
                table: "PokemonPokemonType",
                columns: new[] { "PokemonTypesId", "PokemonsId" });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_BreedingId",
                table: "Pokemons",
                column: "BreedingId");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonPokemonType_PokemonTypes_PokemonTypesId",
                table: "PokemonPokemonType",
                column: "PokemonTypesId",
                principalTable: "PokemonTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonPokemonType_Pokemons_PokemonsId",
                table: "PokemonPokemonType",
                column: "PokemonsId",
                principalTable: "Pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_Breedings_BreedingId",
                table: "Pokemons",
                column: "BreedingId",
                principalTable: "Breedings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
