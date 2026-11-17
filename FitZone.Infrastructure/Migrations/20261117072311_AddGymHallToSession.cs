using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitZone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGymHallToSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GymHallId",
                table: "WorkoutSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessions_GymHallId",
                table: "WorkoutSessions",
                column: "GymHallId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSessions_GymHalls_GymHallId",
                table: "WorkoutSessions",
                column: "GymHallId",
                principalTable: "GymHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSessions_GymHalls_GymHallId",
                table: "WorkoutSessions");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutSessions_GymHallId",
                table: "WorkoutSessions");

            migrationBuilder.DropColumn(
                name: "GymHallId",
                table: "WorkoutSessions");
        }
    }
}
