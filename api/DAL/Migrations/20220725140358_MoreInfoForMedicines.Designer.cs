﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(HospitalContext))]
    [Migration("20220725140358_MoreInfoForMedicines")]
    partial class MoreInfoForMedicines
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CORE.Models.Doctor", b =>
                {
                    b.Property<string>("Surname")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<byte>("Experience")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("HospitalUnitName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Surname", "Name", "Patronymic");

                    b.HasIndex("HospitalUnitName");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Surname = "Сєдих",
                            Name = "Олександр",
                            Patronymic = "Миколайович",
                            BirthDate = new DateTime(1970, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Experience = (byte)29,
                            HospitalUnitName = "Хірургічне відділення"
                        },
                        new
                        {
                            Surname = "Суманов",
                            Name = "Сергій",
                            Patronymic = "Валерійович",
                            BirthDate = new DateTime(1971, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Experience = (byte)28,
                            HospitalUnitName = "Хірургічне відділення"
                        },
                        new
                        {
                            Surname = "Літвінов",
                            Name = "Геннадій",
                            Patronymic = "Володимирович",
                            BirthDate = new DateTime(1955, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Experience = (byte)44,
                            HospitalUnitName = "Хірургічне відділення"
                        },
                        new
                        {
                            Surname = "Соловьова",
                            Name = "Валентина",
                            Patronymic = "Георгіївна",
                            BirthDate = new DateTime(1976, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Experience = (byte)24,
                            HospitalUnitName = "Пульмонологічне відділення"
                        },
                        new
                        {
                            Surname = "Шелест",
                            Name = "Світлана",
                            Patronymic = "Сергіївна",
                            BirthDate = new DateTime(1978, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Experience = (byte)17,
                            HospitalUnitName = "Пульмонологічне відділення"
                        });
                });

            modelBuilder.Entity("CORE.Models.HospitalUnit", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Name");

                    b.ToTable("HospitalUnits");

                    b.HasData(
                        new
                        {
                            Name = "Хірургічне відділення",
                            Profession = "Хірург"
                        },
                        new
                        {
                            Name = "Пульмонологічне відділення",
                            Profession = "Пульмонолог"
                        });
                });

            modelBuilder.Entity("CORE.Models.HospitalWard", b =>
                {
                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<short>("BedsQuantity")
                        .HasColumnType("smallint");

                    b.Property<string>("HospitalUnitName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Number");

                    b.HasIndex("HospitalUnitName");

                    b.ToTable("HospitalWards");

                    b.HasData(
                        new
                        {
                            Number = 101,
                            BedsQuantity = (short)15,
                            HospitalUnitName = "Хірургічне відділення"
                        },
                        new
                        {
                            Number = 102,
                            BedsQuantity = (short)15,
                            HospitalUnitName = "Хірургічне відділення"
                        },
                        new
                        {
                            Number = 103,
                            BedsQuantity = (short)10,
                            HospitalUnitName = "Хірургічне відділення"
                        },
                        new
                        {
                            Number = 104,
                            BedsQuantity = (short)10,
                            HospitalUnitName = "Хірургічне відділення"
                        },
                        new
                        {
                            Number = 201,
                            BedsQuantity = (short)10,
                            HospitalUnitName = "Пульмонологічне відділення"
                        },
                        new
                        {
                            Number = 202,
                            BedsQuantity = (short)8,
                            HospitalUnitName = "Пульмонологічне відділення"
                        });
                });

            modelBuilder.Entity("CORE.Models.Illness", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("HospitalUnitName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Procedures")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Symptoms")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.HasKey("Name");

                    b.HasIndex("HospitalUnitName");

                    b.ToTable("Illnesses");

                    b.HasData(
                        new
                        {
                            Name = "Хвороба №1",
                            HospitalUnitName = "Хірургічне відділення",
                            Procedures = "Розумний текст №1...",
                            Symptoms = "Симптоми №1"
                        },
                        new
                        {
                            Name = "Хвороба №2",
                            HospitalUnitName = "Хірургічне відділення",
                            Procedures = "Розумний текст №2...",
                            Symptoms = "Симптоми №2"
                        },
                        new
                        {
                            Name = "Хвороба №3",
                            HospitalUnitName = "Хірургічне відділення",
                            Procedures = "Розумний текст №3...",
                            Symptoms = "Симптоми №3"
                        },
                        new
                        {
                            Name = "Хвороба №4",
                            HospitalUnitName = "Пульмонологічне відділення",
                            Procedures = "Розумний текст №4...",
                            Symptoms = "Симптоми №4"
                        },
                        new
                        {
                            Name = "Хвороба №5",
                            HospitalUnitName = "Пульмонологічне відділення",
                            Procedures = "Розумний текст №5...",
                            Symptoms = "Симптоми №5"
                        });
                });

            modelBuilder.Entity("CORE.Models.Medicine", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("DosageForm")
                        .HasColumnType("varchar(100)");

                    b.Property<short>("QuantityInStock")
                        .HasColumnType("smallint");

                    b.Property<string>("UnitOfMeasure")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Name");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("CORE.Models.Patient", b =>
                {
                    b.Property<string>("Surname")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AttendingDoctorName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AttendingDoctorPatronymic")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AttendingDoctorSurname")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateOfAdmission")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("HospitalWardNumber")
                        .HasColumnType("int");

                    b.HasKey("Surname", "Name", "Patronymic");

                    b.HasIndex("Diagnosis");

                    b.HasIndex("HospitalWardNumber");

                    b.HasIndex("AttendingDoctorSurname", "AttendingDoctorName", "AttendingDoctorPatronymic");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("CORE.Models.Treatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("IllnessName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("MedicineName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<byte>("MedicineQuantity")
                        .HasColumnType("tinyint unsigned");

                    b.HasKey("Id");

                    b.HasIndex("IllnessName");

                    b.HasIndex("MedicineName");

                    b.ToTable("Treatments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IllnessName = "Хвороба №1",
                            MedicineName = "Ліки №4",
                            MedicineQuantity = (byte)2
                        },
                        new
                        {
                            Id = 2,
                            IllnessName = "Хвороба №1",
                            MedicineName = "Ліки №5",
                            MedicineQuantity = (byte)1
                        },
                        new
                        {
                            Id = 3,
                            IllnessName = "Хвороба №2",
                            MedicineName = "Ліки №8",
                            MedicineQuantity = (byte)5
                        },
                        new
                        {
                            Id = 4,
                            IllnessName = "Хвороба №2",
                            MedicineName = "Ліки №3",
                            MedicineQuantity = (byte)3
                        },
                        new
                        {
                            Id = 5,
                            IllnessName = "Хвороба №3",
                            MedicineName = "Ліки №4",
                            MedicineQuantity = (byte)2
                        },
                        new
                        {
                            Id = 6,
                            IllnessName = "Хвороба №4",
                            MedicineName = "Ліки №4",
                            MedicineQuantity = (byte)2
                        },
                        new
                        {
                            Id = 7,
                            IllnessName = "Хвороба №5",
                            MedicineName = "Ліки №1",
                            MedicineQuantity = (byte)1
                        },
                        new
                        {
                            Id = 8,
                            IllnessName = "Хвороба №5",
                            MedicineName = "Ліки №2",
                            MedicineQuantity = (byte)3
                        },
                        new
                        {
                            Id = 9,
                            IllnessName = "Хвороба №5",
                            MedicineName = "Ліки №10",
                            MedicineQuantity = (byte)3
                        });
                });

            modelBuilder.Entity("CORE.Models.Doctor", b =>
                {
                    b.HasOne("CORE.Models.HospitalUnit", "HospitalUnit")
                        .WithMany("Doctors")
                        .HasForeignKey("HospitalUnitName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HospitalUnit");
                });

            modelBuilder.Entity("CORE.Models.HospitalWard", b =>
                {
                    b.HasOne("CORE.Models.HospitalUnit", "HospitalUnit")
                        .WithMany("HospitalWards")
                        .HasForeignKey("HospitalUnitName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HospitalUnit");
                });

            modelBuilder.Entity("CORE.Models.Illness", b =>
                {
                    b.HasOne("CORE.Models.HospitalUnit", "HospitalUnit")
                        .WithMany("Illnesses")
                        .HasForeignKey("HospitalUnitName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HospitalUnit");
                });

            modelBuilder.Entity("CORE.Models.Patient", b =>
                {
                    b.HasOne("CORE.Models.Illness", "Illness")
                        .WithMany()
                        .HasForeignKey("Diagnosis")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CORE.Models.HospitalWard", "HospitalWard")
                        .WithMany("Patients")
                        .HasForeignKey("HospitalWardNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CORE.Models.Doctor", "AttendingDoctor")
                        .WithMany()
                        .HasForeignKey("AttendingDoctorSurname", "AttendingDoctorName", "AttendingDoctorPatronymic");

                    b.Navigation("AttendingDoctor");

                    b.Navigation("HospitalWard");

                    b.Navigation("Illness");
                });

            modelBuilder.Entity("CORE.Models.Treatment", b =>
                {
                    b.HasOne("CORE.Models.Illness", "Illness")
                        .WithMany("Treatments")
                        .HasForeignKey("IllnessName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CORE.Models.Medicine", "Medicine")
                        .WithMany()
                        .HasForeignKey("MedicineName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Illness");

                    b.Navigation("Medicine");
                });

            modelBuilder.Entity("CORE.Models.HospitalUnit", b =>
                {
                    b.Navigation("Doctors");

                    b.Navigation("HospitalWards");

                    b.Navigation("Illnesses");
                });

            modelBuilder.Entity("CORE.Models.HospitalWard", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("CORE.Models.Illness", b =>
                {
                    b.Navigation("Treatments");
                });
#pragma warning restore 612, 618
        }
    }
}
