﻿// <auto-generated />
using System;
using ExamOnline.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExamOnline.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ExamOnline.Models.Duration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ApplicantId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId")
                        .IsUnique();

                    b.ToTable("TB_M_Duration");
                });

            modelBuilder.Entity("ExamOnline.Models.ExamDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DurationId")
                        .HasColumnType("int");

                    b.Property<int>("FinalScore")
                        .HasColumnType("int");

                    b.Property<int>("GradeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DurationId")
                        .IsUnique();

                    b.HasIndex("GradeId")
                        .IsUnique();

                    b.ToTable("TB_M_ExamDetail");
                });

            modelBuilder.Entity("ExamOnline.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Grades")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Grade");
                });

            modelBuilder.Entity("ExamOnline.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AnswerA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnswerB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnswerC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnswerD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorrectAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<string>("Quest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SegmentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SegmentId");

                    b.ToTable("TB_M_Question");
                });

            modelBuilder.Entity("ExamOnline.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("ScheduleTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Schedule");
                });

            modelBuilder.Entity("ExamOnline.Models.Segment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("QuestionQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Segment");
                });

            modelBuilder.Entity("ExamOnline.Models.Duration", b =>
                {
                    b.HasOne("ExamOnline.Models.Schedule", "Schedule")
                        .WithOne("Duration")
                        .HasForeignKey("ExamOnline.Models.Duration", "ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("ExamOnline.Models.ExamDetail", b =>
                {
                    b.HasOne("ExamOnline.Models.Duration", "Duration")
                        .WithOne("ExamDetail")
                        .HasForeignKey("ExamOnline.Models.ExamDetail", "DurationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExamOnline.Models.Grade", "Grade")
                        .WithOne("ExamDetail")
                        .HasForeignKey("ExamOnline.Models.ExamDetail", "GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Duration");

                    b.Navigation("Grade");
                });

            modelBuilder.Entity("ExamOnline.Models.Question", b =>
                {
                    b.HasOne("ExamOnline.Models.Segment", "Segment")
                        .WithMany()
                        .HasForeignKey("SegmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Segment");
                });

            modelBuilder.Entity("ExamOnline.Models.Duration", b =>
                {
                    b.Navigation("ExamDetail");
                });

            modelBuilder.Entity("ExamOnline.Models.Grade", b =>
                {
                    b.Navigation("ExamDetail");
                });

            modelBuilder.Entity("ExamOnline.Models.Schedule", b =>
                {
                    b.Navigation("Duration");
                });
#pragma warning restore 612, 618
        }
    }
}
