using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSData.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOldColumnFromUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Users",
                type: "datetime2",
                nullable: true);
        }
    }
}
