using System.ComponentModel.DataAnnotations;

namespace AnimalShelterApi.Models
{
  public class Dog
  {
    public int DogId { get; set; }
    [Required]
    [StringLength(20)]
    public string Name { get; set; }
    [Required]
    public string Breed { get; set; }
    [Required]
    [Range(0, 200, ErrorMessage = "Age must be between 0 and 200.")]
    public int Age { get; set; }
  }
}