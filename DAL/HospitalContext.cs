using CORE.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class HospitalContext: DbContext
{
    public HospitalContext(DbContextOptions<HospitalContext> options): base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>().HasKey(d => new {d.Surname, d.Name, d.Patronymic});
        modelBuilder.Entity<Patient>().HasKey(p => new {p.Surname, p.Name, p.Patronymic});
    }
    
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Illness> Illnesses { get; set; }
    public DbSet<Medicine> Medicines { get; set; }
    public DbSet<Profession> Professions { get; set; }
    public DbSet<HospitalWard> HospitalWards { get; set; }
    public DbSet<HospitalUnit> HospitalUnits { get; set; }
    public DbSet<PrescribedTreatment> PrescribedTreatments { get; set; }
    public DbSet<RecommendedTreatment> RecommendedTreatments { get; set; }
}