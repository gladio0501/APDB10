using Microsoft.AspNetCore.Mvc;
using Task10.Models;
using Task10.DTOs;
using Task10.Services;

[ApiController]
[Route("[controller]")]
public class PrescriptionController : ControllerBase
{
    private readonly IDbService _dbService;

    public PrescriptionController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    [Route("AddPrescription")]
    public async Task<IActionResult> AddPrescriptionAsync(PrescriptionDTO prescriptionDto)
    {
        // Map PatientDTO to Patient
        var patient = new Patient
        {
            Id = prescriptionDto.PatientDto.Id,
            FirstName = prescriptionDto.PatientDto.FirstName,
            LastName = prescriptionDto.PatientDto.LastName,
            Birthdate = prescriptionDto.PatientDto.Birthdate
        };

        // Check if the patient exists
        var existingPatient = await _dbService.GetPatientByIdAsync(patient.Id);
        if (existingPatient == null)
        {
            await _dbService.AddPatientAsync(patient);
            existingPatient = patient;
        }

        // Validate medicaments and map MedicamentDTO to Medicament
        var medicaments = new List<Medicament>();
        foreach (var medicamentDto in prescriptionDto.MedicamentDto)
        {
            var medicament = new Medicament
            {
                Id = medicamentDto.Id,
                Name = medicamentDto.Name,
                Description = medicamentDto.Description,
                Type = "Type"
            };

            var existingMedicament = await _dbService.GetMedicamentByIdAsync(medicament.Id);
            if (existingMedicament == null)
            {
                return BadRequest("Medicament does not exist");
            }
            medicaments.Add(medicament);
        }

        // Validate the number of medicaments
        if (medicaments.Count > 10)
        {
            return BadRequest("A prescription can include a maximum of 10 medications");
        }

        // Validate prescription dates
        if (prescriptionDto.DueDate < prescriptionDto.Date)
        {
            return BadRequest("DueDate must be greater than or equal to Date");
        }

        // Map DoctorDTO to Doctor
        var doctor = new Doctor
        {
            Id = prescriptionDto.DoctorDto.Id,
            FirstName = prescriptionDto.DoctorDto.FirstName,
            LastName = prescriptionDto.DoctorDto.LastName
        };

        // Create Prescription
        var prescription = new Prescription
        {
            Date = prescriptionDto.Date,
            DueDate = prescriptionDto.DueDate,
            Patient = existingPatient,
            Doctor = doctor
        };

        // Add the prescription to the database
        await _dbService.AddPrescriptionAsync(prescription);

        // Add each medicament to the prescription
        foreach (var medicament in medicaments)
        {
            var prescriptionMedicament = new Prescription_Medicament
            {
                Prescription = prescription,
                Medicament = medicament
            };
            await _dbService.AddPrescriptionMedicamentAsync(prescriptionMedicament);
        }

        return Ok("Prescription added successfully");
    }
}
