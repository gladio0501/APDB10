using Microsoft.EntityFrameworkCore;

namespace Task10.Data;

public class ApplicationContext : DbContext
{
    protected ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Models.Patient> Patients { get; set; }
    public DbSet<Models.Doctor> Doctors { get; set; }
    public DbSet<Models.Medicament> Medicaments { get; set; }
    public DbSet<Models.Prescription> Prescriptions { get; set; }
    public DbSet<Models.Prescription_Medicament> Prescription_Medicaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // // Seeding Patients
        // modelBuilder.Entity<Models.Patient>().HasData(
        //     new Models.Patient { IdPatient = 1, FirstName = "John", LastName = "Doe", Birthdate = new DateTime(1980, 1, 1) },
        //     new Models.Patient { IdPatient = 2, FirstName = "Jane", LastName = "Doe", Birthdate = new DateTime(1985, 1, 1) }
        // );
        //
        // // Seeding Doctors
        // modelBuilder.Entity<Models.Doctor>().HasData(
        //     new Models.Doctor { IdDoctor = 1, FirstName = "Dr. Smith", LastName = "Johnson", Email = "drsmith@hospital.com" },
        //     new Models.Doctor { IdDoctor = 2, FirstName = "Dr. Jane", LastName = "Johnson", Email = "drjane@hospital.com" }
        // );
        //
        // // Seeding Prescriptions
        // modelBuilder.Entity<Models.Prescription>().HasData(
        //     new Models.Prescription { IdPrescription = 1, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(30), IdPatient = 1, IdDoctor = 1 },
        //     new Models.Prescription { IdPrescription = 2, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(30), IdPatient = 2, IdDoctor = 2 }
        // );
        //
        // // Seeding Prescription_Medicament
        // modelBuilder.Entity<Models.Prescription_Medicament>().HasData(
        //     new Models.Prescription_Medicament { IdPrescription = 1, IdMedicament = 1,Dose = 5, Details = "Take one pill after meals" },
        //     new Models.Prescription_Medicament { IdPrescription = 2, IdMedicament = 2,Dose = 8, Details = "Take two pills before sleep" }
        // );
    }
}