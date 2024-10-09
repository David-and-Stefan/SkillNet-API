﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkillNet.Infrastructure.Common.Persistence;

#nullable disable

namespace SkillNet.Infrastructure.Migrations
{
    [DbContext(typeof(SkillNetDbContext))]
    partial class SkillNetDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MemberGroups", b =>
                {
                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("MemberId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("MemberGroups", (string)null);
                });

            modelBuilder.Entity("SkillNet.Domain.Organizations.Models.Members.JoinRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("MemberId");

                    b.ToTable("JoinRequests");
                });

            modelBuilder.Entity("SkillNet.Domain.Organizations.Models.Members.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("SkillNet.Domain.Organizations.Models.Organizations.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("SkillNet.Domain.Organizations.Models.Organizations.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("SkillNet.Domain.Organizations.Models.Organizations.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("MemberGroups", b =>
                {
                    b.HasOne("SkillNet.Domain.Organizations.Models.Organizations.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SkillNet.Domain.Organizations.Models.Members.Member", null)
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SkillNet.Domain.Organizations.Models.Members.JoinRequest", b =>
                {
                    b.HasOne("SkillNet.Domain.Organizations.Models.Organizations.Group", null)
                        .WithMany("JoinRequests")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SkillNet.Domain.Organizations.Models.Members.Member", "Member")
                        .WithMany("JoinRequests")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("SkillNet.Domain.Organizations.Models.Organizations.Employee", b =>
                {
                    b.HasOne("SkillNet.Domain.Organizations.Models.Organizations.Organization", null)
                        .WithMany("Employees")
                        .HasForeignKey("OrganizationId");

                    b.OwnsOne("SkillNet.Domain.Organizations.Models.Common.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<int>("EmployeeId")
                                .HasColumnType("int");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.OwnsOne("SkillNet.Domain.Organizations.Models.Common.Pronouns", "Pronouns", b1 =>
                        {
                            b1.Property<int>("EmployeeId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.Navigation("PhoneNumber")
                        .IsRequired();

                    b.Navigation("Pronouns")
                        .IsRequired();
                });

            modelBuilder.Entity("SkillNet.Domain.Organizations.Models.Organizations.Group", b =>
                {
                    b.HasOne("SkillNet.Domain.Organizations.Models.Organizations.Employee", "Manager")
                        .WithMany("ManagedGroups")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SkillNet.Domain.Organizations.Models.Organizations.Organization", "Organization")
                        .WithMany("Groups")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Manager");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("SkillNet.Domain.Organizations.Models.Members.Member", b =>
                {
                    b.Navigation("JoinRequests");
                });

            modelBuilder.Entity("SkillNet.Domain.Organizations.Models.Organizations.Employee", b =>
                {
                    b.Navigation("ManagedGroups");
                });

            modelBuilder.Entity("SkillNet.Domain.Organizations.Models.Organizations.Group", b =>
                {
                    b.Navigation("JoinRequests");
                });

            modelBuilder.Entity("SkillNet.Domain.Organizations.Models.Organizations.Organization", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Groups");
                });
#pragma warning restore 612, 618
        }
    }
}
