using Task10.Models;

namespace Task10.DTOs;

public class PrescriptionDTO
{
    public PatientDTO PatientDto { get; set; }
    public MedicamentDTO[] MedicamentDto { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public DoctorDTO DoctorDto { get; set; }
    public class MedicamentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Dose { get; set; }
        
        public string Description { get; set; } = null!;
    }
    public class PatientDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime Birthdate { get; set; }
    }
    
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}

