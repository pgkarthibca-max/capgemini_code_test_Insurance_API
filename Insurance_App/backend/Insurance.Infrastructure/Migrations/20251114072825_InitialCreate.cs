using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Insurance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "occupations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OccupationName = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<string>(type: "text", nullable: false),
                    RatingFactor = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_occupations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AgeNextBirthday = table.Column<int>(type: "integer", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OccupationId = table.Column<int>(type: "integer", nullable: false),
                    DeathSumInsured = table.Column<decimal>(type: "numeric", nullable: false),
                    MonthlyPremium = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_members_occupations_OccupationId",
                        column: x => x.OccupationId,
                        principalTable: "occupations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "occupations",
                columns: new[] { "Id", "OccupationName", "Rating", "RatingFactor" },
                values: new object[,]
                {
                    { 1, "Cleaner", "Light Manual", 1.50m },
                    { 2, "Doctor", "Professional", 1.50m },
                    { 3, "Author", "White Collar", 2.25m },
                    { 4, "Farmer", "Heavy Manual", 3.75m },
                    { 5, "Mechanic", "Heavy Manual", 3.75m },
                    { 6, "Florist", "Light Manual", 1.50m },
                    { 7, "Other", "Heavy Manual", 3.75m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_members_OccupationId",
                table: "members",
                column: "OccupationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "members");

            migrationBuilder.DropTable(
                name: "occupations");
        }
    }
}
