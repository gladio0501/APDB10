using Microsoft.AspNetCore.Mvc;
using Task10.Services;
using Task10.DTOs;

namespace Task10.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController : ControllerBase
{
    private readonly IDbService _dbService;

    public PatientController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{patientId}")]
    public async Task<IActionResult> GetPatientDetailsAsync(int patientId)
    {
        var patient = await _dbService.GetPatientByIdAsync(patientId);
        if (patient == null)
        {
            return NotFound("Patient not found");
        }

        var patientDetails = new PatientDetailsDTO
        {
            Id = patient.Id,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Birthdate = patient.Birthdate,
            Prescriptions = await _dbService.GetPatientPrescriptionsAsync(patientId)
        };

        return Ok(patientDetails);
    }
}