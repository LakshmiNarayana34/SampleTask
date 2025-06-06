﻿// <auto-generated />
using System;
using InTimeOutTime.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InTimeOutTime.Migrations
{
    [DbContext(typeof(EmployeeInTimeOutTimeDbContext))]
    [Migration("20250204110724_EmpUpdateInTimeOutTime1")]
    partial class EmpUpdateInTimeOutTime1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InTimeOutTime.Model.EmployeeTimeSheet", b =>
                {
                    b.Property<string>("EmpId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OutTime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpId", "Date");

                    b.ToTable("employeeTimeSheets");
                });
#pragma warning restore 612, 618
        }
    }
}
