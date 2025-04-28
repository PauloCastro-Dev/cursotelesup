using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTicket.Models
{
    public class Comment
    {
        private static int _nextId = 1;
        public int Id { get; set; }
        public Persona? Author { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime CreatedDateMyProperty { get; set; }
    }
}