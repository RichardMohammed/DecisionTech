using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RM.Supermarket.Migrations
{
    public partial class resolveProductIssues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiscountId",
                table: "Products",
                newName: "Discount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
