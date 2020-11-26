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
    [Migration("20201118014401_updateModelsApplicant")]
    partial class updateModelsApplicant
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

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

                    b.Property<string>("DocPath")
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("Portal.Models.ApplicantSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ApplicantId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.HasIndex("SkillId");

                    b.ToTable("TB_T_ApplicantSkill");
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

            modelBuilder.Entity("Portal.Models.ApplicantSkill", b =>
                {
                    b.HasOne("Portal.Models.Applicant", "Applicant")
                        .WithMany("ApplicantSkills")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portal.Models.Skill", "Skill")
                        .WithMany("ApplicantSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Portal.Models.Applicant", b =>
                {
                    b.Navigation("ApplicantSkills");
                });

            modelBuilder.Entity("Portal.Models.Position", b =>
                {
                    b.Navigation("Applicants");
                });

            modelBuilder.Entity("Portal.Models.Reference", b =>
                {
                    b.Navigation("Applicants");
                });

            modelBuilder.Entity("Portal.Models.Skill", b =>
                {
                    b.Navigation("ApplicantSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
