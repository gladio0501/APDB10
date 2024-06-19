using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task10.Models;
public class Patient
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; } = null!;
    [MaxLength(100)]
    public string LastName { get; set; } = null!;
    public DateTime Birthdate { get; set; }
    
    public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
}