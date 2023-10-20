using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LasPollasHermanas.Client.Models
{
    public class Comprado
    {
        public int Id { get; set; }

        // Definir la relación con Users
        public int UserId { get; set; }
        public Users User { get; set; }

        // Definir la relación con Dildo
        public int DildoId { get; set; }
        public Dildo Dildo { get; set; }

        public DateTime comprado { get; set; }

    }
}