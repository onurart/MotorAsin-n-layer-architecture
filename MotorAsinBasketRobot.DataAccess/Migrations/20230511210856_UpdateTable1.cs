using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorAsinBasketRobot.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "MASqlConnection");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "MASqlConnection",
                type: "bigint",
                nullable: true);
        }
    }
}
