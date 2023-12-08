using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSHospital.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedUsesss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_AppUserId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_AppUserId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_Users_AppUserId",
                table: "Hospitals");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Hospitals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_AppUserId",
                table: "Appointments",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_AppUserId",
                table: "Departments",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_Users_AppUserId",
                table: "Hospitals",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_AppUserId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_AppUserId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_Users_AppUserId",
                table: "Hospitals");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Hospitals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_AppUserId",
                table: "Appointments",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_AppUserId",
                table: "Departments",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_Users_AppUserId",
                table: "Hospitals",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
