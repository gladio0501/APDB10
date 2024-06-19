using Task10.Data;
using Task10.Models;
using Microsoft.EntityFrameworkCore;
using Task10.DTOs;

namespace Task10.Services;

public class DbService : IDbService
{
    private readonly ApplicationContext _context;

    public DbService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Patient?> GetPatientByIdAsync(int id)
    {
        return await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddPatientAsync(Patient patient)
    {
        await _context.Patients.AddAsync(patient);
        await _context.SaveChangesAsync();
    }

    public async Task<Medicament?> GetMedicamentByIdAsync(int id)
    {
        return await _context.Medicaments.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddPrescriptionAsync(Prescription prescription)
    {
        await _context.Prescriptions.AddAsync(prescription);
        await _context.SaveChangesAsync();
    }

    public async Task AddPrescriptionMedicamentAsync(Prescription_Medicament prescriptionMedicament)
    {
        await _context.Prescription_Medicaments.AddAsync(prescriptionMedicament);
        await _context.SaveChangesAsync();
    }

    public async Task<List<PrescriptionDetailsDTO>> GetPatientPrescriptionsAsync(int patientId)
    {
        return await _context.Prescriptions
            .Where(p => p.Patient.Id == patientId)
            .Include(p => p.Doctor)
            .Include(p => p.Prescription_Medicaments)
            .ThenInclude(pm => pm.Medicament)
            .OrderBy(p => p.DueDate)
            .Select(p => new PrescriptionDetailsDTO
            {
                Id = p.Id,
                Date = p.Date,
                DueDate = p.DueDate,
                Doctor = new DoctorDTO
                {
                    Id = p.Doctor.Id,
                    FirstName = p.Doctor.FirstName,
                    LastName = p.Doctor.LastName
                },
                Medicaments = p.Prescription_Medicaments
                    .Select(pm => new MedicamentDTO
                    {
                        Id = pm.Medicament.Id,
                        Name = pm.Medicament.Name,
                        Dose = 12,
                        Description = pm.Medicament.Description
                    }).ToList()
            }).ToListAsync();
    }
}