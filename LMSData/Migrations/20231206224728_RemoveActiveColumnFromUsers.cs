﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSData.Migrations
{
    /// <inheritdoc />
    public partial class RemoveActiveColumnFromUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: true);
        }
    }
}
