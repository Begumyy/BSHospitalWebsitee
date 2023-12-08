using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSHospital.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedUsesssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Users_AppUserId",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Users_AppUserId",
                table: "Patients",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Users_AppUserId",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Users_AppUserId",
                table: "Patients",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
