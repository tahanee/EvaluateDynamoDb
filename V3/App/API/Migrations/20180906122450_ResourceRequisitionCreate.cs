using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace guid_reactapp.Migrations
{
    public partial class ResourceRequisitionCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Job_Requisition = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Stages = table.Column<int>(nullable: false),
                    File_Name = table.Column<string>(nullable: true),
                    Deadline = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceRequisitions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    HiringManagerEmail = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Skills = table.Column<string>(nullable: true),
                    Stages = table.Column<int>(nullable: false),
                    PlannedDeadline = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceRequisitions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "ResourceRequisitions");
        }
    }
}
