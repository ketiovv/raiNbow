﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RaiNbow.Core.Storage;

#nullable disable

namespace RaiNbow.Core.Storage.Migrations
{
    [DbContext(typeof(RaiNbowContext))]
    [Migration("20240307222125_FieldType")]
    partial class FieldType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("data")
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RaiNbow.Cms.Field", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("FieldTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SchemaId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("FieldTypeId");

                    b.HasIndex("SchemaId");

                    b.ToTable("Fields", "data");
                });

            modelBuilder.Entity("RaiNbow.Cms.FieldType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FieldName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FieldType", "data");
                });

            modelBuilder.Entity("RaiNbow.Cms.Schema", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Schemas", "data");
                });

            modelBuilder.Entity("RaiNbow.Cms.Field", b =>
                {
                    b.HasOne("RaiNbow.Cms.FieldType", "FieldType")
                        .WithMany("Fields")
                        .HasForeignKey("FieldTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RaiNbow.Cms.Schema", "Schema")
                        .WithMany("Fields")
                        .HasForeignKey("SchemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FieldType");

                    b.Navigation("Schema");
                });

            modelBuilder.Entity("RaiNbow.Cms.FieldType", b =>
                {
                    b.Navigation("Fields");
                });

            modelBuilder.Entity("RaiNbow.Cms.Schema", b =>
                {
                    b.Navigation("Fields");
                });
#pragma warning restore 612, 618
        }
    }
}
