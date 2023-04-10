using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AluraChallenge.Adopet.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAdopetTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adopets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adopets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adopets_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Adopets_Tutors_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adopets_PetId",
                table: "Adopets",
                column: "PetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adopets_TutorId",
                table: "Adopets",
                column: "TutorId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adopets");
        }
    }
}
