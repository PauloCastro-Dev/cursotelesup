using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoTicket.Models.Enums;

namespace ProyectoTicket.Models
{
    public class Ticket
    {
        private static int _nextId = 1;
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TicketStatus Status { get; set; }
        public Priority Priority { get; set; }
        public TicketCategory Category { get; set; }
        public string ReportedBy { get; set; } = string.Empty;
        public DateTime CreatedDateMyProperty { get; set; }
        public DateTime LastUpdated { get; set; }
        public Developer? Developer { get; set; }
        public List<Comment> Comments { get; set; } = [];
    }
}