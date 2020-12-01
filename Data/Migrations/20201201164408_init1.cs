using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace myPictures.Data.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "IconImage",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IconImageType",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconImage",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IconImageType",
                table: "AspNetUsers");
        }
    }
}
