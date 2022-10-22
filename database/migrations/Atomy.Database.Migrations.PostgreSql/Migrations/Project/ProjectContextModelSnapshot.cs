﻿// <auto-generated />
using System;
using Atomy.Database.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Atomy.Database.Migrations.PostgreSql.Migrations.Project
{
    [DbContext(typeof(ProjectContext))]
    partial class ProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Atomy.SDK.DAL.LinkRecord", b =>
                {
                    b.Property<Guid>("DbId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProjectRecordId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SourceId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TargetId")
                        .HasColumnType("uuid");

                    b.HasKey("DbId");

                    b.HasIndex("ProjectRecordId");

                    b.ToTable("AtomyLinks");
                });

            modelBuilder.Entity("Atomy.SDK.DAL.PortRecord", b =>
                {
                    b.Property<Guid>("DbId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Brand")
                        .HasColumnType("integer");

                    b.Property<int>("Direction")
                        .HasColumnType("integer");

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("StepRecordId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DbId");

                    b.HasIndex("StepRecordId");

                    b.ToTable("AtomyPorts");
                });

            modelBuilder.Entity("Atomy.SDK.DAL.ProjectMetaRecord", b =>
                {
                    b.Property<Guid>("DbId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("ProjectRecordId")
                        .HasColumnType("uuid");

                    b.Property<string>("ServiceUniqueName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("DbId");

                    b.HasIndex("ProjectRecordId")
                        .IsUnique();

                    b.ToTable("AtomyProjectMetas");
                });

            modelBuilder.Entity("Atomy.SDK.DAL.ProjectRecord", b =>
                {
                    b.Property<Guid>("DbId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("DbId");

                    b.ToTable("AtomyProjects");
                });

            modelBuilder.Entity("Atomy.SDK.DAL.StepRecord", b =>
                {
                    b.Property<Guid>("DbId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MetaInfoId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ProjectRecordId")
                        .HasColumnType("uuid");

                    b.Property<int>("X")
                        .HasColumnType("integer");

                    b.Property<int>("Y")
                        .HasColumnType("integer");

                    b.HasKey("DbId");

                    b.HasIndex("MetaInfoId");

                    b.HasIndex("ProjectRecordId");

                    b.ToTable("AtomySteps");
                });

            modelBuilder.Entity("Atomy.SDK.PluginMetaInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AssemblyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AssemblyVersion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PluginMetaInfo");
                });

            modelBuilder.Entity("Atomy.SDK.DAL.LinkRecord", b =>
                {
                    b.HasOne("Atomy.SDK.DAL.ProjectRecord", "ProjectRecord")
                        .WithMany("Links")
                        .HasForeignKey("ProjectRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectRecord");
                });

            modelBuilder.Entity("Atomy.SDK.DAL.PortRecord", b =>
                {
                    b.HasOne("Atomy.SDK.DAL.StepRecord", "StepRecord")
                        .WithMany("Ports")
                        .HasForeignKey("StepRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StepRecord");
                });

            modelBuilder.Entity("Atomy.SDK.DAL.ProjectMetaRecord", b =>
                {
                    b.HasOne("Atomy.SDK.DAL.ProjectRecord", null)
                        .WithOne("Meta")
                        .HasForeignKey("Atomy.SDK.DAL.ProjectMetaRecord", "ProjectRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Atomy.SDK.DAL.StepRecord", b =>
                {
                    b.HasOne("Atomy.SDK.PluginMetaInfo", "MetaInfo")
                        .WithMany()
                        .HasForeignKey("MetaInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Atomy.SDK.DAL.ProjectRecord", "ProjectRecord")
                        .WithMany("Steps")
                        .HasForeignKey("ProjectRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MetaInfo");

                    b.Navigation("ProjectRecord");
                });

            modelBuilder.Entity("Atomy.SDK.DAL.ProjectRecord", b =>
                {
                    b.Navigation("Links");

                    b.Navigation("Meta")
                        .IsRequired();

                    b.Navigation("Steps");
                });

            modelBuilder.Entity("Atomy.SDK.DAL.StepRecord", b =>
                {
                    b.Navigation("Ports");
                });
#pragma warning restore 612, 618
        }
    }
}
