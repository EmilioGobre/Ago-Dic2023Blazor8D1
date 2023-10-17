using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LasPollasHermanas.Client.Models
{
  public class Users
  {
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string? Name { get; set; }
    [Required]
    [Range(1, 100)]
    public string? Sername { get; set; }
    [Required]
    [Range(1, 100)]
    public string? Email { get; set; }
    [Required]
    [Range(1, 100)]
    public string? Password { get; set; }
    [Required]
    [Range(1, 100)]
    public int Puesto { get; set; }
    public DateTime fechaNacimiento { get; set; }
    public List<Dildo>? dildosActuales { get; set; }
    public List<Dildo>? historial { get; set; }
  }
}