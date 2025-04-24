using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoSistemaTareas.Enums;

namespace ProyectoSistemaTareas.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public Prioridad Prioridad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Completada { get; set; }

    }
}