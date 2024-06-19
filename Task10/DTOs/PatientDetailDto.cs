namespace Task10.DTOs

{
    public class PatientDetailsDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime Birthdate { get; set; }
        public List<PrescriptionDetailsDTO> Prescriptions { get; set; } = new();
    }

    public class PrescriptionDetailsDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public DoctorDTO Doctor { get; set; } = null!;
        public List<MedicamentDTO> Medicaments { get; set; } = new();
    }

    public class DoctorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }

    public class MedicamentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Dose { get; set; }
        public string Description { get; set; } = null!;
    }
}
