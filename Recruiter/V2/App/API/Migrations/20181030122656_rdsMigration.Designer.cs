﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace API.Migrations
{
    [DbContext(typeof(TableContext))]
    [Migration("20181030122656_rdsMigration")]
    partial class rdsMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("CandidateModel.Models.MyCandidates", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CandidateEmail");

                    b.Property<DateTime>("PanelDeadline");

                    b.Property<string>("ResourceRequisition");

                    b.Property<string>("ResumeText");

                    b.Property<string>("ResumeUpload");

                    b.Property<int>("Stages");

                    b.HasKey("Id");

                    b.ToTable("MyCandidates");
                });

            modelBuilder.Entity("Models.Recruiter.ResourceRequisition", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("HiringManagerEmail");

                    b.Property<string>("Notes");

                    b.Property<DateTime>("PlannedDeadline");

                    b.Property<string>("Skills");

                    b.Property<int>("Stages");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("ResourceRequisitions");
                });

            modelBuilder.Entity("Models.SkillSets.SkillSet", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Node");

                    b.Property<string>("Parent");

                    b.HasKey("Id");

                    b.ToTable("SkillSets");
                });

            modelBuilder.Entity("QandAApi.Models.Item", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ans");

                    b.Property<string>("Ques");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
