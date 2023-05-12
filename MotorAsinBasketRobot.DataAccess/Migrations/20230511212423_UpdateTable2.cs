using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorAsinBasketRobot.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Format",
                table: "MASqlConnection",
                type: "TinyInt",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "Float",
                oldMaxLength: 250);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Format",
                table: "MASqlConnection",
                type: "Float",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TinyInt",
                oldMaxLength: 250);
        }
    }
}
