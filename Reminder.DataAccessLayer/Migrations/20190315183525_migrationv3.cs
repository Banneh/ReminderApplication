﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reminder.DataAccessLayer.Migrations
{
    public partial class migrationv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ToDos",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "ToDos",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
