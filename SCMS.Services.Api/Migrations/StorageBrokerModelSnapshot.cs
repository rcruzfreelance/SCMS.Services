﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SCMS.Services.Api.Brokers.Storages;

#nullable disable

namespace SCMS.Services.Api.Migrations
{
    [DbContext(typeof(StorageBroker))]
    partial class StorageBrokerModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0-rc.1.21452.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SCMS.Services.Api.Models.Foundations.Emails.Email", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("GuardianId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("GuardianId")
                        .IsUnique();

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("SCMS.Services.Api.Models.Foundations.Guardians.Guardian", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Title")
                        .HasColumnType("int");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Guardians");
                });

            modelBuilder.Entity("SCMS.Services.Api.Models.Foundations.Occupations.Occupation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("GuardianId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("GuardianId");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Occupations");
                });

            modelBuilder.Entity("SCMS.Services.Api.Models.Foundations.Phones.Phone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("GuardianId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("GuardianId")
                        .IsUnique();

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("SCMS.Services.Api.Models.Foundations.Schools.School", b =>
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

            modelBuilder.Entity("SCMS.Services.Api.Models.Foundations.StudentGuardians.StudentGuardian", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GuardianId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("Relation")
                        .HasColumnType("int");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("StudentId", "GuardianId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("GuardianId");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("StudentGuardians");
                });

            modelBuilder.Entity("SCMS.Services.Api.Models.Foundations.Students.Student", b =>
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

                    b.Property<string>("FideId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SchoolId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("SchoolId");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SCMS.Services.Api.Models.Foundations.Users.User", b =>
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

            modelBuilder.Entity("SCMS.Services.Api.Models.Foundations.Emails.Email", b =>
                {
                    b.HasOne("SCMS.Services.Api.Models.Foundations.Users.User", "CreatedByUser")
                        .WithMany("CreatedEmails")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SCMS.Services.Api.Models.Foundations.Guardians.Guardian", "Guardian")
                        .WithOne("RegisteredEmail")
                        .HasForeignKey("SCMS.Services.Api.Models.Foundations.Emails.Email", "GuardianId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SCMS.Services.Api.Models.Foundations.Users.User", "UpdatedByUser")
                        .WithMany("UpdatedEmails")
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("Guardian");

                    b.Navigation("UpdatedByUser");
                });

            modelBuilder.Entity("SCMS.Services.Api.Models.Foundations.Guardians.Guardian", b =>
                {
                    b.HasOne("SCMS.Services.Api.Models.Foundations.Users.User", "CreatedByUser")
                        .WithMany("CreatedGuardians")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SCMS.Services.Api.Models.Foundations.Users.User", "UpdatedByUser")
                        .WithMany("UpdatedGuardians")
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("UpdatedByUser");
                });

            modelBuilder.Entity("SCMS.Services.Api.Models.Foundations.Occupations.Occupation", b =>
                {
                    b.HasOne("SCMS.Services.Api.Models.Foundations.Users.User", "CreatedByUser")
                        .WithMany("CreatedOccupations")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SCMS.Services.Api.Models.Foundations.Guardians.Guardian", "Guardian")
                        .WithMany("RegisteredOccupations")
                        .HasForeignKey("GuardianId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SCMS.Services.Api.Models.Foundations.Users.User", "UpdatedByUser")
                        .WithMany("UpdatedOccupations")
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("Guardian");

                    b.Navigation("UpdatedByUser");
                });

            modelBuilder.Entity("SCMS.Services.Api.Models.Foundations.Phones.Phone", b =>
                {
                    b.HasOne("SCMS.Services.Api.Models.Foundations.Users.User", "CreatedByUser")
                        .WithMany("CreatedPhones")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SCMS.Services.Api.Models.Foundations.Guardians.Guardian", "Guardian")
                        .WithOne("RegisteredPhone")
                        .HasForeignKey("SCMS.Services.Api.Models.Foundations.Phones.Phone", "GuardianId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SCMS.Services.Api.Models.Foundations.Users.User", "UpdatedByUser")
                        .WithMany("UpdatedPhones")
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("Guardian");

                    b.Navigation("UpdatedByUser");
                });

            modelBuilder.Entity("SCMS.Services.Api.Models.Foundations.Schools.School", b =>
                {
                    b.HasOne("SCMS.Services.Api.Models.Foundations.Users.User", "CreatedByUser")
                        .WithMany("CreatedSchools")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SCMS.Services.Api.Models.Foundations.Users.User", "UpdatedByUser")
                        .WithMany("UpdatedSchools")
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("UpdatedByUser");
                });

            modelBuilder.Entity("SCMS.Services.Api.Models.Foundations.StudentGuardians.StudentGuardian", b =>
                {
                    b.HasOne("SCMS.Services.Api.Models.Foundations.Users.User", "CreatedByUser")
                        .WithMany("CreatedStudentGuardians")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SCMS.Services.Api.Models.Foundations.Guardians.Guardian", "Guardian")
                        .WithMany("RegisteredStudents")
                        .HasForeignKey("GuardianId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SCMS.Services.Api.Models.Foundations.Students.Student", "Student")
                        .WithMany("RegisteredGuardians")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SCMS.Services.Api.Models.Foundations.Users.User", "UpdatedByUser")
                        .WithMany("UpdatedStudentGuardians")
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("Guardian");

                    b.Navigation("Student");

                    b.Navigation("UpdatedByUser");
                });

            modelBuilder.Entity("SCMS.Services.Api.Models.Foundations.Students.Student", b =>
                {
                    b.HasOne("SCMS.Services.Api.Models.Foundations.Users.User", "CreatedByUser")
                        .WithMany("CreatedStudents")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SCMS.Services.Api.Models.Foundations.Schools.School", "EnrolledSchool")
                        .WithMany("EnrolledStudents")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SCMS.Services.Api.Models.Foundations.Users.User", "UpdatedByUser")
                        .WithMany("UpdatedStudents")
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("EnrolledSchool");

                    b.Navigation("UpdatedByUser");
                });

            modelBuilder.Entity("SCMS.Services.Api.Models.Foundations.Guardians.Guardian", b =>
                {
                    b.Navigation("RegisteredEmail");

                    b.Navigation("RegisteredOccupations");

                    b.Navigation("RegisteredPhone");

                    b.Navigation("RegisteredStudents");
                });

            modelBuilder.Entity("SCMS.Services.Api.Models.Foundations.Schools.School", b =>
                {
                    b.Navigation("EnrolledStudents");
                });

            modelBuilder.Entity("SCMS.Services.Api.Models.Foundations.Students.Student", b =>
                {
                    b.Navigation("RegisteredGuardians");
                });

            modelBuilder.Entity("SCMS.Services.Api.Models.Foundations.Users.User", b =>
                {
                    b.Navigation("CreatedEmails");

                    b.Navigation("CreatedGuardians");

                    b.Navigation("CreatedOccupations");

                    b.Navigation("CreatedPhones");

                    b.Navigation("CreatedSchools");

                    b.Navigation("CreatedStudentGuardians");

                    b.Navigation("CreatedStudents");

                    b.Navigation("UpdatedEmails");

                    b.Navigation("UpdatedGuardians");

                    b.Navigation("UpdatedOccupations");

                    b.Navigation("UpdatedPhones");

                    b.Navigation("UpdatedSchools");

                    b.Navigation("UpdatedStudentGuardians");

                    b.Navigation("UpdatedStudents");
                });
#pragma warning restore 612, 618
        }
    }
}
