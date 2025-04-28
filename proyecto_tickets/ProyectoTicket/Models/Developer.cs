using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoTicket.Models.Enums;

namespace ProyectoTicket.Models
{
    public class Developer
    {
        private static int _nextId = 1;
        public int Id { get; set; }
        public Role Role { get; set; }
        public int Seniority { get; set; }
        public List<Ticket> Tickets { get; set; } = [];
    }
}