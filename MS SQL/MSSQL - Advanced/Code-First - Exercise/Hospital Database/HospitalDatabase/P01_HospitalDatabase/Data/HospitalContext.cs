using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=HospitalDatabase;Integrated Security=True");
            }

            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Patient> Patients { get; set; }

        public virtual DbSet<Visitation> Visitations { get; set; }

        public virtual DbSet<Diagnose> Diagnoses { get; set; }

        public virtual DbSet<Medicament> Medicaments { get; set; }

        public virtual DbSet<Doctor> Doctors { get; set; }

        public virtual DbSet<PatientMedicament> PatientMedicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicament>(e =>
            {
                e.HasKey(pm => new {pm.MedicamentId, pm.PatientId});
            });
        }
    }
}
