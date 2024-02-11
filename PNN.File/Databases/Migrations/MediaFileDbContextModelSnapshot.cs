﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PNN.File.Databases;

#nullable disable

namespace MediaFile.Databases.Migrations
{
    [DbContext(typeof(MediaFileDbContext))]
    partial class MediaFileDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PNN.File.Domain.MediaFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("FixedSize")
                        .HasColumnType("integer");

                    b.Property<int>("FolderId")
                        .HasColumnType("integer");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<int?>("MediaStorageId")
                        .HasColumnType("integer");

                    b.Property<string>("MediaType")
                        .HasColumnType("text");

                    b.Property<string>("MetaData")
                        .HasColumnType("text");

                    b.Property<string>("MimeType")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("text");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("Version")
                        .HasColumnType("integer");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.ToTable("MediaFiles", (string)null);
                });

            modelBuilder.Entity("PNN.File.Domain.MediaFolder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FilesCount")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("text");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("MediaFolders", (string)null);
                });

            modelBuilder.Entity("PNN.File.Domain.MediaFile", b =>
                {
                    b.HasOne("PNN.File.Domain.MediaFolder", "MediaFolder")
                        .WithMany("MediaFiles")
                        .HasForeignKey("FolderId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("MediaFolder");
                });

            modelBuilder.Entity("PNN.File.Domain.MediaFolder", b =>
                {
                    b.Navigation("MediaFiles");
                });
#pragma warning restore 612, 618
        }
    }
}
