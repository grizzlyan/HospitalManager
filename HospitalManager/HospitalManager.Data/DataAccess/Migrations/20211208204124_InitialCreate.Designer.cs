﻿// <auto-generated />
using System;
using HospitalManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospitalManager.Data.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211208204124_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HospitalManager.Data.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("HospitalManager.Data.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PathToPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpecializationId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SpecializationId");

                    b.HasIndex("UserId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("HospitalManager.Data.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HospitalManager.Data.Entities.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecializationName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Specializations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Лечение геморроя и других проктологических заболеваний с помощью малоинвазивных методик.",
                            SpecializationName = "Проктология"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Мужская и женская урология.Лечение проблем с потенцией.Консультация андролога.",
                            SpecializationName = "Урология"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Диагностика и лечение патологий шейки матки, воспалительных и невоспалительных заболеваний.",
                            SpecializationName = "Гинекология"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Диагностика и лечение дерматологических заболеваний. Удаление кожных новообразований.",
                            SpecializationName = "Дерматология"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Эффективное лечение заболеваний желудочно-кишечного тракта. Консультации по вопросам питания.",
                            SpecializationName = "Гастроэнтерология"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Диагностика и лечение заболеваний эндокринной системы: ожирения, сахарного диабета и щитовидной железы.",
                            SpecializationName = "Эндокринология"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Лечение заболеваний сердечно-сосудистой системы человека. Проведение ЭКГ, УЗИ сердца.",
                            SpecializationName = "Кардиология"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Диагностика и лечение заболеваний ЛОР-органов (уши, горло, нос). Удаление инородных предметов и серных пробок.",
                            SpecializationName = "Отоларингология"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Диагностика и лечение заболеваний нервной системы человека. Лечение нарушений слуха, речи, памяти.",
                            SpecializationName = "Неврология"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Диагностика и лечение заболеваний молочных желез. Пункция, УЗИ. Консультации маммолога-онколога.",
                            SpecializationName = "Маммология"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Удаление доброкачественных подкожных новообразований малоинвазивными методами. Консультации хирурга.",
                            SpecializationName = "Хирургия"
                        },
                        new
                        {
                            Id = 12,
                            Description = "Диагностика и лечение заболеваний вен (атеросклероз, тромбоз, заболеваний аорты). Лечение варикоза.",
                            SpecializationName = "Флебология"
                        },
                        new
                        {
                            Id = 13,
                            Description = "Диагностика и лечение заболеваний органов дыхания (легкие, бронхи, трахеи). Лечение последствий курения.",
                            SpecializationName = "Пульмонология"
                        },
                        new
                        {
                            Id = 14,
                            Description = "Диагностика, лечение и профилактика аллергии различного происхождения. Анализы на аллергены.",
                            SpecializationName = "Аллергология"
                        },
                        new
                        {
                            Id = 15,
                            Description = "Лечение заболеваний опорно-двигательного аппарата. Укол-блокады, prp-терапия.",
                            SpecializationName = "Травматология"
                        },
                        new
                        {
                            Id = 16,
                            Description = "Диагностика, лечение и профилактика инфекционных заболеваний.",
                            SpecializationName = "Инфектология"
                        },
                        new
                        {
                            Id = 17,
                            Description = "Диагностика и лечение нарушений зрения у взрослых и детей. Подбор средств для зрения.",
                            SpecializationName = "Офтальмология"
                        },
                        new
                        {
                            Id = 18,
                            Description = "Диагностика и лечение заболеваний почек: мочекаменная болезнь, пиелонефрит, хроническая болезнь почек.",
                            SpecializationName = "Нефрология"
                        },
                        new
                        {
                            Id = 19,
                            Description = "Диагностика и лечение различных заболеваний крови и системы кроветворения.",
                            SpecializationName = "Гематология"
                        },
                        new
                        {
                            Id = 20,
                            Description = "Лечение и профилактика заболеваний суставов и соединительной ткани.",
                            SpecializationName = "Ревматология"
                        },
                        new
                        {
                            Id = 21,
                            Description = "Диагностика и лечение пациентов с острыми и тяжелыми психическими состояниями.",
                            SpecializationName = "Психотерапия"
                        },
                        new
                        {
                            Id = 22,
                            Description = "Устранение косметических дефектов, а также деформаций тканей и органов.",
                            SpecializationName = "Пластическая хирургия"
                        },
                        new
                        {
                            Id = 23,
                            Description = "Оперативное лечение заболеваний центральной и периферической нервной системы.",
                            SpecializationName = "Нейрохирургия"
                        });
                });

            modelBuilder.Entity("HospitalManager.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "3d102e9d-17cf-4533-a8a3-645b44ad3fe9",
                            ConcurrencyStamp = "2751fda9-4651-42e7-b45a-c11eae7ec1fc",
                            Name = "Manager"
                        },
                        new
                        {
                            Id = "67938b3b-fbb7-489f-a107-baea92a941b1",
                            ConcurrencyStamp = "60c07283-362c-4a87-b37f-4e299cdaf953",
                            Name = "Doctor"
                        },
                        new
                        {
                            Id = "aad20197-7c0d-4ab2-9074-a0811fac0546",
                            ConcurrencyStamp = "0e7ab8d3-f671-4149-a5ea-e11ea2e97643",
                            Name = "Patient"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HospitalManager.Data.Entities.Appointment", b =>
                {
                    b.HasOne("HospitalManager.Data.Entities.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManager.Data.Entities.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalManager.Data.Entities.Doctor", b =>
                {
                    b.HasOne("HospitalManager.Data.Entities.Specialization", "Specialization")
                        .WithMany("Doctors")
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManager.Data.Entities.User", "User")
                        .WithMany("Doctors")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specialization");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HospitalManager.Data.Entities.Patient", b =>
                {
                    b.HasOne("HospitalManager.Data.Entities.User", "User")
                        .WithMany("Patients")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HospitalManager.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HospitalManager.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManager.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HospitalManager.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalManager.Data.Entities.Doctor", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("HospitalManager.Data.Entities.Patient", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("HospitalManager.Data.Entities.Specialization", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("HospitalManager.Data.Entities.User", b =>
                {
                    b.Navigation("Doctors");

                    b.Navigation("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}
