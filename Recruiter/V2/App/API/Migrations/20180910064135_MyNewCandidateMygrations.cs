using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace guid_reactapp.Migrations
{
    public partial class MyNewCandidateMygrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.CreateTable(
                name: "MyCandidates",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ResourceRequisition = table.Column<string>(nullable: true),
                    CandidateEmail = table.Column<string>(nullable: true),
                    Stages = table.Column<int>(nullable: false),
                    ResumeText = table.Column<string>(nullable: true),
                    ResumeUpload = table.Column<string>(nullable: true),
                    PanelDeadline = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyCandidates", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyCandidates");

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    File_Name = table.Column<string>(nullable: true),
                    Job_Requisition = table.Column<string>(nullable: true),
                    Stages = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });
        }
    }
}
