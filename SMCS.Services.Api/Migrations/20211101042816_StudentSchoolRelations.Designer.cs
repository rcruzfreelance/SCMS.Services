﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SMCS.Services.Api.Brokers.Storages;

#nullable disable

namespace SMCS.Services.Api.Migrations
{
    [DbContext(typeof(StorageBroker))]
    [Migration("20211101042816_StudentSchoolRelations")]
    partial class StudentSchoolRelations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0-rc.1.21452.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SMCS.Services.Api.Models.Foundations.Schools.School", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("SMCS.Services.Api.Models.Foundations.Students.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("UpdateDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SMCS.Services.Api.Models.Foundations.StudentSchools.StudentSchool", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SchoolId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("StudentId", "SchoolId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("SchoolId");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.HasIndex("UpdatedBy");

                    b.ToTable("StudentSchools");
                });

            modelBuilder.Entity("SMCS.Services.Api.Models.Foundations.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ddbda33e-4df4-44ca-945d-62fec7f73973"),
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("SMCS.Services.Api.Models.Foundations.Schools.School", b =>
                {
                    b.HasOne("SMCS.Services.Api.Models.Foundations.Users.User", "CreatedByUser")
                        .WithMany("CreatedSchools")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SMCS.Services.Api.Models.Foundations.Users.User", "UpdatedByUser")
                        .WithMany("UpdatedSchools")
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("UpdatedByUser");
                });

            modelBuilder.Entity("SMCS.Services.Api.Models.Foundations.Students.Student", b =>
                {
                    b.HasOne("SMCS.Services.Api.Models.Foundations.Users.User", "CreatedByUser")
                        .WithMany("CreatedStudents")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SMCS.Services.Api.Models.Foundations.Users.User", "UpdatedByUser")
                        .WithMany("UpdatedStudents")
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("UpdatedByUser");
                });

            modelBuilder.Entity("SMCS.Services.Api.Models.Foundations.StudentSchools.StudentSchool", b =>
                {
                    b.HasOne("SMCS.Services.Api.Models.Foundations.Users.User", "CreatedByUser")
                        .WithMany("CreatedStudentSchools")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SMCS.Services.Api.Models.Foundations.Schools.School", "StudyingSchool")
                        .WithMany("EnrolledStudents")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SMCS.Services.Api.Models.Foundations.Students.Student", "StudingStudent")
                        .WithOne("EnrolledSchool")
                        .HasForeignKey("SMCS.Services.Api.Models.Foundations.StudentSchools.StudentSchool", "StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SMCS.Services.Api.Models.Foundations.Users.User", "UpdatedByUser")
                        .WithMany("UpdatedStudentSchools")
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("StudingStudent");

                    b.Navigation("StudyingSchool");

                    b.Navigation("UpdatedByUser");
                });

            modelBuilder.Entity("SMCS.Services.Api.Models.Foundations.Schools.School", b =>
                {
                    b.Navigation("EnrolledStudents");
                });

            modelBuilder.Entity("SMCS.Services.Api.Models.Foundations.Students.Student", b =>
                {
                    b.Navigation("EnrolledSchool");
                });

            modelBuilder.Entity("SMCS.Services.Api.Models.Foundations.Users.User", b =>
                {
                    b.Navigation("CreatedSchools");

                    b.Navigation("CreatedStudentSchools");

                    b.Navigation("CreatedStudents");

                    b.Navigation("UpdatedSchools");

                    b.Navigation("UpdatedStudentSchools");

                    b.Navigation("UpdatedStudents");
                });
#pragma warning restore 612, 618
        }
    }
}
