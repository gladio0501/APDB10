using Task10.DTOs;
using Task10.Models;

namespace Task10.Services;

public interface IDbService
{
    Task<Patient?> GetPatientByIdAsync(int id);
    Task AddPatientAsync(Patient patient);
    Task<Medicament?> GetMedicamentByIdAsync(int id);
    Task AddPrescriptionAsync(Prescription prescription);
    Task AddPrescriptionMedicamentAsync(Prescription_Medicament prescriptionMedicament);
    Task<List<PrescriptionDetailsDTO>> GetPatientPrescriptionsAsync(int patientId);
}