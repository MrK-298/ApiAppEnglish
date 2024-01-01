﻿// <auto-generated />
using System;
using ApiAppEnglish.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiAppEnglish.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240101072711_update8")]
    partial class update8
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiAppEnglish.Data.EF.DetailHomework", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("homeworkId")
                        .HasColumnType("int");

                    b.Property<bool>("isDone")
                        .HasColumnType("bit");

                    b.Property<int>("score")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("homeworkId");

                    b.HasIndex("userId");

                    b.ToTable("DetailHomeWork");
                });

            modelBuilder.Entity("ApiAppEnglish.Data.EF.Homework", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("topicId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("topicId");

                    b.ToTable("Homework");
                });

            modelBuilder.Entity("ApiAppEnglish.Data.EF.ListWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("definition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phonetic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("word")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ListWord");
                });

            modelBuilder.Entity("ApiAppEnglish.Data.EF.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("ApiAppEnglish.Data.EF.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VerificationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("emailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("fullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("passWord")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("ApiAppEnglish.Data.EF.DetailHomework", b =>
                {
                    b.HasOne("ApiAppEnglish.Data.EF.Homework", "homework")
                        .WithMany()
                        .HasForeignKey("homeworkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiAppEnglish.Data.EF.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("homework");

                    b.Navigation("user");
                });

            modelBuilder.Entity("ApiAppEnglish.Data.EF.Homework", b =>
                {
                    b.HasOne("ApiAppEnglish.Data.EF.Topic", null)
                        .WithMany("homeworks")
                        .HasForeignKey("topicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApiAppEnglish.Data.EF.ListWord", b =>
                {
                    b.HasOne("ApiAppEnglish.Data.EF.User", null)
                        .WithMany("List")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApiAppEnglish.Data.EF.Topic", b =>
                {
                    b.Navigation("homeworks");
                });

            modelBuilder.Entity("ApiAppEnglish.Data.EF.User", b =>
                {
                    b.Navigation("List");
                });
#pragma warning restore 612, 618
        }
    }
}
