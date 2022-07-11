﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FluentValidationApp.Web.Migrations
{
    public partial class add_prop_birthday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Customers");
        }
    }
}
