﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reminder.DataAccessLayer.DAL;

namespace Reminder.DataAccessLayer.Migrations
{
    [DbContext(typeof(ToDoContext))]
    [Migration("20190314223245_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Reminder.DataAccessLayer.DataModels.Group", b =>
                {
                    b.Property<long>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Reminder.DataAccessLayer.DataModels.ToDo", b =>
                {
                    b.Property<long>("ToDoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime?>("DueDate");

                    b.Property<long?>("GroupId");

                    b.Property<bool>("IsDone");

                    b.Property<string>("Name");

                    b.HasKey("ToDoId");

                    b.HasIndex("GroupId");

                    b.ToTable("ToDos");
                });

            modelBuilder.Entity("Reminder.DataAccessLayer.DataModels.ToDo", b =>
                {
                    b.HasOne("Reminder.DataAccessLayer.DataModels.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");
                });
#pragma warning restore 612, 618
        }
    }
}
