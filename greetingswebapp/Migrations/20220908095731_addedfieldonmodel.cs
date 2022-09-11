﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace greetingswebapp.Migrations
{
    public partial class addedfieldonmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Commands",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Commands");
        }
    }
}
