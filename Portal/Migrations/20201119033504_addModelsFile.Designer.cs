﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portal.Context;

namespace Portal.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20201119033504_addModelsFile")]
    partial class addModelsFile
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ApplicantSkill", b =>
                {
                    b.Property<int>("ApplicantsId")
                        .HasColumnType("int");

                    b.Property<int>("SkillsId")
                        .HasColumnType("int");

                    b.HasKey("ApplicantsId", "SkillsId");

                    b.HasIndex("SkillsId");

                    b.ToTable("ApplicantSkill");
                });

            modelBuilder.Entity("Portal.Models.Applicant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("AlreadyCheck")
                        .HasColumnType("bit");

                    b.Property<bool>("AlreadyTest")
                        .HasColumnType("bit");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("PositionId")
                        .HasColumnType("int");

                    b.Property<int?>("ReferenceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("ReferenceId");

                    b.ToTable("TB_M_Applicant");
                });

            modelBuilder.Entity("Portal.Models.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ApplicantId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("DataFile")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId")
                        .IsUnique();

                    b.ToTable("TB_M_Files");
                });

            modelBuilder.Entity("Portal.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Position");
                });

            modelBuilder.Entity("Portal.Models.Reference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Reference");
                });

            modelBuilder.Entity("Portal.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Skill");
                });

            modelBuilder.Entity("ApplicantSkill", b =>
                {
                    b.HasOne("Portal.Models.Applicant", null)
                        .WithMany()
                        .HasForeignKey("ApplicantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portal.Models.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Portal.Models.Applicant", b =>
                {
                    b.HasOne("Portal.Models.Position", "Position")
                        .WithMany("Applicants")
                        .HasForeignKey("PositionId");

                    b.HasOne("Portal.Models.Reference", "Reference")
                        .WithMany("Applicants")
                        .HasForeignKey("ReferenceId");

                    b.Navigation("Position");

                    b.Navigation("Reference");
                });

            modelBuilder.Entity("Portal.Models.File", b =>
                {
                    b.HasOne("Portal.Models.Applicant", "Applicant")
                        .WithOne("File")
                        .HasForeignKey("Portal.Models.File", "ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("Portal.Models.Applicant", b =>
                {
                    b.Navigation("File");
                });

            modelBuilder.Entity("Portal.Models.Position", b =>
                {
                    b.Navigation("Applicants");
                });

            modelBuilder.Entity("Portal.Models.Reference", b =>
                {
                    b.Navigation("Applicants");
                });
#pragma warning restore 612, 618
        }
    }
}
