﻿// <auto-generated />
using MakaleProject.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MakaleProject.Migrations
{
    [DbContext(typeof(ArticleDbContext))]
    [Migration("20240606095420_mig3")]
    partial class mig3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("ArticleDetailsUser", b =>
                {
                    b.Property<int>("ArticleDetailsMakeleID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsersID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ArticleDetailsMakeleID", "UsersID");

                    b.HasIndex("UsersID");

                    b.ToTable("ArticleDetailsUser");
                });

            modelBuilder.Entity("MakaleProject.Models.ArticleDetails", b =>
                {
                    b.Property<int>("MakeleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ArContent")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CommentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MakeleID");

                    b.ToTable("ArticleDetails");
                });

            modelBuilder.Entity("MakaleProject.Models.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticleDetailsMakeleID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticleID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("CommentID");

                    b.HasIndex("ArticleDetailsMakeleID");

                    b.HasIndex("UserID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("MakaleProject.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MakaleProject.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MailAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ArticleDetailsUser", b =>
                {
                    b.HasOne("MakaleProject.Models.ArticleDetails", null)
                        .WithMany()
                        .HasForeignKey("ArticleDetailsMakeleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MakaleProject.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MakaleProject.Models.Comment", b =>
                {
                    b.HasOne("MakaleProject.Models.ArticleDetails", "ArticleDetails")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleDetailsMakeleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MakaleProject.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArticleDetails");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MakaleProject.Models.User", b =>
                {
                    b.HasOne("MakaleProject.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MakaleProject.Models.ArticleDetails", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("MakaleProject.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("MakaleProject.Models.User", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
