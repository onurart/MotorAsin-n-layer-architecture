﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework.Context;

#nullable disable

namespace MotorAsinBasketRobot.DataAccess.Migrations.MaMusteri
{
    [DbContext(typeof(MaMusteriContext))]
    partial class MaMusteriContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MotorAsinBasketRobot.Entities.Concrete.BasketStatus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<string>("CustomerCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DeletedId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LastModifiedId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BasketStatuses");
                });

            modelBuilder.Entity("MotorAsinBasketRobot.Entities.Concrete.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<string>("CustomerCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomerReferance")
                        .HasColumnType("int");

                    b.Property<long?>("DeletedId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LastModifiedId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MotorAsinBasketRobot.Entities.Concrete.Documents", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<short?>("Billed")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<int?>("CustomerReferance")
                        .HasColumnType("int");

                    b.Property<long?>("DeletedId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DocumentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short?>("DocumetType")
                        .HasColumnType("smallint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LastModifiedId")
                        .HasColumnType("bigint");

                    b.Property<short?>("LineType")
                        .HasColumnType("smallint");

                    b.Property<int?>("ProductReferance")
                        .HasColumnType("int");

                    b.Property<double?>("TlToltal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("MotorAsinBasketRobot.Entities.Concrete.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<long?>("DeletedId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LastModifiedId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductGroup1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductGroup2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductGroup3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductGroup4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductReferance")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MotorAsinBasketRobot.Entities.Concrete.ProductsCampaigns", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<long?>("DeletedId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LastModifiedId")
                        .HasColumnType("bigint");

                    b.Property<double?>("MinOrder")
                        .HasColumnType("float");

                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductGroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductReferance")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProductCampaigns");
                });
#pragma warning restore 612, 618
        }
    }
}
