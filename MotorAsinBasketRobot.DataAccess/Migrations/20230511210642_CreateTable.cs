using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorAsinBasketRobot.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MASqlConnection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "Int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnmConnetion = table.Column<byte>(type: "TinyInt", nullable: true),
                    CustomerCode = table.Column<string>(type: "NVarChar(250)", maxLength: 250, nullable: true),
                    ServerName = table.Column<string>(type: "NVarChar(250)", maxLength: 250, nullable: true),
                    DbName = table.Column<string>(type: "NVarChar(250)", maxLength: 250, nullable: true),
                    UserName = table.Column<string>(type: "NVarChar(250)", maxLength: 250, nullable: true),
                    Password = table.Column<string>(type: "NVarChar(250)", maxLength: 250, nullable: true),
                    Encrypt = table.Column<string>(type: "NVarChar(250)", maxLength: 250, nullable: true),
                    Failover = table.Column<string>(type: "NVarChar(250)", maxLength: 250, nullable: true),
                    Certificate = table.Column<string>(type: "NVarChar(250)", maxLength: 250, nullable: true),
                    ApplicationIntent = table.Column<string>(type: "NVarChar(250)", maxLength: 250, nullable: true),
                    Timeout = table.Column<double>(type: "Float", maxLength: 250, nullable: true),
                    Format = table.Column<double>(type: "Float", maxLength: 250, nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedId = table.Column<long>(type: "bigint", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MASqlConnection", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MASqlConnection");
        }
    }
}
