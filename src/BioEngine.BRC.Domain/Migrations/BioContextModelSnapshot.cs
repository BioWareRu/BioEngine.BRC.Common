﻿// <auto-generated />
using System;
using BioEngine.Core.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BioEngine.BRC.Domain.Migrations
{
    [DbContext(typeof(BioContext))]
    partial class BioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BioEngine.Core.Entities.ContentItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<bool>("IsPinned");

                    b.Property<bool>("IsPublished");

                    b.Property<int[]>("SectionIds");

                    b.Property<int[]>("SiteIds");

                    b.Property<int[]>("TagIds");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("IsPublished");

                    b.HasIndex("SectionIds");

                    b.HasIndex("SiteIds");

                    b.HasIndex("TagIds");

                    b.HasIndex("Type");

                    b.HasIndex("Url");

                    b.ToTable("Content");

                    b.HasDiscriminator<string>("Type").HasValue("ContentItem");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Items")
                        .HasColumnType("jsonb");

                    b.Property<int[]>("SiteIds");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<bool>("IsPublished");

                    b.Property<int[]>("SiteIds");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.PropertiesRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<string>("EntityId");

                    b.Property<string>("EntityType");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Key")
                        .IsRequired();

                    b.Property<int?>("SiteId");

                    b.HasKey("Id");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<string>("Hashtag")
                        .IsRequired();

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<string>("LogoSmall")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<int?>("ParentId");

                    b.Property<string>("ShortDescription")
                        .IsRequired();

                    b.Property<int[]>("SiteIds");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("IsPublished");

                    b.HasIndex("SiteIds");

                    b.HasIndex("Type");

                    b.HasIndex("Url");

                    b.ToTable("Sections");

                    b.HasDiscriminator<string>("Type").HasValue("Section");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Site", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("BioEngine.BRC.Domain.Entities.File", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.ContentItem");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("Content");

                    b.HasDiscriminator().HasValue("BioEngine.BRC.Domain.Entities.File");
                });

            modelBuilder.Entity("BioEngine.BRC.Domain.Entities.Gallery", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.ContentItem");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("Content");

                    b.HasDiscriminator().HasValue("BioEngine.BRC.Domain.Entities.Gallery");
                });

            modelBuilder.Entity("BioEngine.BRC.Domain.Entities.Post", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.ContentItem");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("Content");

                    b.HasDiscriminator().HasValue("BioEngine.BRC.Domain.Entities.Post");
                });

            modelBuilder.Entity("BioEngine.BRC.Domain.Entities.Developer", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.Section");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("Sections");

                    b.HasDiscriminator().HasValue("BioEngine.BRC.Domain.Entities.Developer");
                });

            modelBuilder.Entity("BioEngine.BRC.Domain.Entities.Game", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.Section");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("Sections");

                    b.HasDiscriminator().HasValue("BioEngine.BRC.Domain.Entities.Game");
                });

            modelBuilder.Entity("BioEngine.BRC.Domain.Entities.Topic", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.Section");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("Sections");

                    b.HasDiscriminator().HasValue("BioEngine.BRC.Domain.Entities.Topic");
                });
#pragma warning restore 612, 618
        }
    }
}
