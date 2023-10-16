using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LasPollasHermanas.Server.Models
{
  public class Users
  {
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string? Name { get; set; }
    [Required]
    [StringLength(50)]
    public string? Sername { get; set; }
    [Required]
    [StringLength(50)]
    public string? Email { get; set; }
    [Required]
    [StringLength(50)]
    public string? Password { get; set; }
    [Required]
    [Range(1, 100)]
    public int Puesto { get; set; }
  }
}