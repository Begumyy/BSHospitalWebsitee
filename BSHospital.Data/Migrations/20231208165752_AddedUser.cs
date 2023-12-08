using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSHospital.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Hospitals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_AppUserId",
                table: "Hospitals",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_AppUserId",
                table: "Departments",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppUserId",
                table: "Appointments",
                column: "AppUserId");

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

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_AppUserId",
                table: "Hospitals");

            migrationBuilder.DropIndex(
                name: "IX_Departments_AppUserId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_AppUserId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Appointments");
        }
    }
}
