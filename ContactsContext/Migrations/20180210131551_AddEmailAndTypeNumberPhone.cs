using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ContactsContext.Migrations
{
    public partial class AddEmailAndTypeNumberPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameCategory",
                table: "Persons",
                newName: "Email");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Persons",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Persons",
                newName: "NameCategory");
        }
    }
}
