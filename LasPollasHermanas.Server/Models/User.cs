using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LasPollasHermanas.Server.Models
{
    public class Users
    {
        [Key]
        public int IdUser { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [Required]
        public string? Sername { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        [Range(1, 100)]
        public int Puesto { get; set; }
        public DateTime fechaNacimiento { get; set; }
    }
}