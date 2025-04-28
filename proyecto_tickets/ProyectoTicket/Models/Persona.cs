using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoTicket.Models.Enums;

namespace ProyectoTicket.Models
{
    public abstract class Persona
    {
        public string Nombre { get; set; } = string.Empty;
        public Genero Genero { get; set; }
        public int Dni { get; set; }
        public string Direccion { get; set; } = string.Empty;
        public int Edad { get; set; }
    }
}