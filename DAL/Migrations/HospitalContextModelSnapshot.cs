﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(HospitalContext))]
    partial class HospitalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("HospitalUnitId")
                        .HasColumnType("int");

                    b.Property<string>("ProfessionName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Surname", "Name", "Patronymic");

                    b.HasIndex("HospitalUnitId");

                    b.HasIndex("ProfessionName");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Surname = "Сєдих",
                            Name = "Олександр",
                            Patronymic = "Миколайович",
                            BirthDate = new DateTime(1970, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Experience = (byte)29,
                            HospitalUnitId = 1,
                            ProfessionName = "Хірург"
                        },
                        new
                        {
                            Surname = "Суманов",
                            Name = "Сергій",
                            Patronymic = "Валерійович",
                            BirthDate = new DateTime(1971, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Experience = (byte)28,
                            HospitalUnitId = 1,
                            ProfessionName = "Хірург"
                        },
                        new
                        {
                            Surname = "Літвінов",
                            Name = "Геннадій",
                            Patronymic = "Володимирович",
                            BirthDate = new DateTime(1955, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Experience = (byte)44,
                            HospitalUnitId = 1,
                            ProfessionName = "Хірург"
                        },
                        new
                        {
                            Surname = "Соловьова",
                            Name = "Валентина",
                            Patronymic = "Георгіївна",
                            BirthDate = new DateTime(1976, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Experience = (byte)24,
                            HospitalUnitId = 2,
                            ProfessionName = "Пульмонолог"
                        },
                        new
                        {
                            Surname = "Шелест",
                            Name = "Світлана",
                            Patronymic = "Сергіївна",
                            BirthDate = new DateTime(1978, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Experience = (byte)17,
                            HospitalUnitId = 2,
                            ProfessionName = "Пульмонолог"
                        });
                });

            modelBuilder.Entity("CORE.Models.HospitalUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("HospitalUnits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Хірургічне відділення"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Пульмонологічне відділення"
                        });
                });

            modelBuilder.Entity("CORE.Models.HospitalWard", b =>
                {
                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<short>("BedsQuantity")
                        .HasColumnType("smallint");

                    b.Property<int>("HospitalUnitId")
                        .HasColumnType("int");

                    b.HasKey("Number");

                    b.HasIndex("HospitalUnitId");

                    b.ToTable("HospitalWards");

                    b.HasData(
                        new
                        {
                            Number = 101,
                            BedsQuantity = (short)15,
                            HospitalUnitId = 1
                        },
                        new
                        {
                            Number = 102,
                            BedsQuantity = (short)15,
                            HospitalUnitId = 1
                        },
                        new
                        {
                            Number = 103,
                            BedsQuantity = (short)10,
                            HospitalUnitId = 1
                        },
                        new
                        {
                            Number = 104,
                            BedsQuantity = (short)10,
                            HospitalUnitId = 1
                        },
                        new
                        {
                            Number = 201,
                            BedsQuantity = (short)10,
                            HospitalUnitId = 2
                        },
                        new
                        {
                            Number = 202,
                            BedsQuantity = (short)8,
                            HospitalUnitId = 2
                        });
                });

            modelBuilder.Entity("CORE.Models.Illness", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("HospitalUnitId")
                        .HasColumnType("int");

                    b.Property<string>("Procedures")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Symptoms")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.HasKey("Name");

                    b.HasIndex("HospitalUnitId");

                    b.ToTable("Illnesses");

                    b.HasData(
                        new
                        {
                            Name = "Хвороба №1",
                            HospitalUnitId = 1,
                            Procedures = "Розумний текст №1...",
                            Symptoms = "Симптоми №1"
                        },
                        new
                        {
                            Name = "Хвороба №2",
                            HospitalUnitId = 1,
                            Procedures = "Розумний текст №2...",
                            Symptoms = "Симптоми №2"
                        },
                        new
                        {
                            Name = "Хвороба №3",
                            HospitalUnitId = 1,
                            Procedures = "Розумний текст №3...",
                            Symptoms = "Симптоми №3"
                        },
                        new
                        {
                            Name = "Хвороба №4",
                            HospitalUnitId = 2,
                            Procedures = "Розумний текст №4...",
                            Symptoms = "Симптоми №4"
                        },
                        new
                        {
                            Name = "Хвороба №5",
                            HospitalUnitId = 2,
                            Procedures = "Розумний текст №5...",
                            Symptoms = "Симптоми №5"
                        });
                });

            modelBuilder.Entity("CORE.Models.Medicine", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.Property<short>("QuantityInStock")
                        .HasColumnType("smallint");

                    b.HasKey("Name");

                    b.ToTable("Medicines");

                    b.HasData(
                        new
                        {
                            Name = "Ліки №1",
                            QuantityInStock = (short)230
                        },
                        new
                        {
                            Name = "Ліки №2",
                            QuantityInStock = (short)430
                        },
                        new
                        {
                            Name = "Ліки №3",
                            QuantityInStock = (short)500
                        },
                        new
                        {
                            Name = "Ліки №4",
                            QuantityInStock = (short)300
                        },
                        new
                        {
                            Name = "Ліки №5",
                            QuantityInStock = (short)150
                        },
                        new
                        {
                            Name = "Ліки №6",
                            QuantityInStock = (short)210
                        },
                        new
                        {
                            Name = "Ліки №7",
                            QuantityInStock = (short)300
                        },
                        new
                        {
                            Name = "Ліки №8",
                            QuantityInStock = (short)630
                        },
                        new
                        {
                            Name = "Ліки №9",
                            QuantityInStock = (short)500
                        },
                        new
                        {
                            Name = "Ліки №10",
                            QuantityInStock = (short)580
                        },
                        new
                        {
                            Name = "Ліки №11",
                            QuantityInStock = (short)210
                        },
                        new
                        {
                            Name = "Ліки №12",
                            QuantityInStock = (short)170
                        });
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
                        .IsRequired()
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

                    b.Property<string>("DiagnosisName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Surname", "Name", "Patronymic");

                    b.HasIndex("DiagnosisName");

                    b.HasIndex("AttendingDoctorSurname", "AttendingDoctorName", "AttendingDoctorPatronymic");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("CORE.Models.Profession", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("HospitalUnitId")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.HasIndex("HospitalUnitId");

                    b.ToTable("Professions");

                    b.HasData(
                        new
                        {
                            Name = "Хірург",
                            HospitalUnitId = 1
                        },
                        new
                        {
                            Name = "Пульмонолог",
                            HospitalUnitId = 2
                        });
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
                    b.HasOne("CORE.Models.HospitalUnit", null)
                        .WithMany("Doctors")
                        .HasForeignKey("HospitalUnitId");

                    b.HasOne("CORE.Models.Profession", "Profession")
                        .WithMany()
                        .HasForeignKey("ProfessionName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profession");
                });

            modelBuilder.Entity("CORE.Models.HospitalWard", b =>
                {
                    b.HasOne("CORE.Models.HospitalUnit", "HospitalUnit")
                        .WithMany("HospitalWards")
                        .HasForeignKey("HospitalUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HospitalUnit");
                });

            modelBuilder.Entity("CORE.Models.Illness", b =>
                {
                    b.HasOne("CORE.Models.HospitalUnit", "HospitalUnit")
                        .WithMany("Illnesses")
                        .HasForeignKey("HospitalUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HospitalUnit");
                });

            modelBuilder.Entity("CORE.Models.Patient", b =>
                {
                    b.HasOne("CORE.Models.Illness", "Diagnosis")
                        .WithMany()
                        .HasForeignKey("DiagnosisName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CORE.Models.Doctor", "AttendingDoctor")
                        .WithMany()
                        .HasForeignKey("AttendingDoctorSurname", "AttendingDoctorName", "AttendingDoctorPatronymic")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttendingDoctor");

                    b.Navigation("Diagnosis");
                });

            modelBuilder.Entity("CORE.Models.Profession", b =>
                {
                    b.HasOne("CORE.Models.HospitalUnit", "HospitalUnit")
                        .WithMany("Professions")
                        .HasForeignKey("HospitalUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HospitalUnit");
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

                    b.Navigation("Professions");
                });

            modelBuilder.Entity("CORE.Models.Illness", b =>
                {
                    b.Navigation("Treatments");
                });
#pragma warning restore 612, 618
        }
    }
}
