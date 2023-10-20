using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LasPollasHermanas.Server.Models
{
    public class dildosComprados
    {
        // Annotations 
        [Key]
        public int Id { get; set; }

        // Definir la relación con Users
        [ForeignKey("IdUser")]
        public int UserId { get; set; }
        public Users User { get; set; }

        // Definir la relación con Dildo
        [ForeignKey("IdDildo")]
        public int DildoId { get; set; }
        public Dildo Dildo { get; set; }

        public DateTime comprado { get; set; }
    }
}