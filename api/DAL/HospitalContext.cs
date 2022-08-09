using CORE.Models;
using CORE.ModelsConfiguration;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasKey(d => new { d.Surname, d.Name, d.Patronymic });
            modelBuilder.Entity<Patient>().HasKey(p => new { p.Surname, p.Name, p.Patronymic });

            modelBuilder.ApplyConfiguration(new HospitalUnitsConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorsConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalWardsConfiguration());
            modelBuilder.ApplyConfiguration(new MedicinesConfiguration());
            modelBuilder.ApplyConfiguration(new IllnessesConfiguration());
            modelBuilder.ApplyConfiguration(new TreatmentsConfiguration());
        }

        public DbSet<Doctor>? Doctors { get; set; }
        public DbSet<Patient>? Patients { get; set; }
        public DbSet<Illness>? Illnesses { get; set; }
        public DbSet<Medicine>? Medicines { get; set; }
        public DbSet<Treatment>? Treatments { get; set; }
        public DbSet<HospitalWard>? HospitalWards { get; set; }
        public DbSet<HospitalUnit>? HospitalUnits { get; set; }
    }
}