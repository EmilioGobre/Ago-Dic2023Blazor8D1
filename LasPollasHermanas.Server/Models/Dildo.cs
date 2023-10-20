using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LasPollasHermanas.Server.Models
{
    public class Dildo
    {
        // Annotations 
        [Key]
        public int IdDildo { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [Required]
        [Range(1, 100)]
        public decimal Price { get; set; }
        [Required]
        public decimal Size { get; set; }
        [Required]
        public DateTime ExpireDate { get; set; }
        [Required]
        public string? Material { get; set; }
        [Required]
        public string? Color { get; set; }
        [Required]
        public int Stock { get; set; }
    }
}