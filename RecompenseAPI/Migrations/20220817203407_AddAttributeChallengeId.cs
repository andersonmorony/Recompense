using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecompenseAPI.Migrations
{
    public partial class AddAttributeChallengeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Challenges_ChallengeId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "ChallengeId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Challenges_ChallengeId",
                table: "Questions",
                column: "ChallengeId",
                principalTable: "Challenges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Challenges_ChallengeId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "ChallengeId",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Challenges_ChallengeId",
                table: "Questions",
                column: "ChallengeId",
                principalTable: "Challenges",
                principalColumn: "Id");
        }
    }
}
