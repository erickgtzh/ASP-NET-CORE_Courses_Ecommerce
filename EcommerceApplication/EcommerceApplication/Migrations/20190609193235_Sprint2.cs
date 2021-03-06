﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceApplication.Migrations
{
    public partial class Sprint2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductImagePath",
                table: "Product",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "ProductImagePath",
                table: "Product",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
