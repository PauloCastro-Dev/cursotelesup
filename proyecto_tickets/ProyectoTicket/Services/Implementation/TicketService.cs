using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoTicket.Models;
using ProyectoTicket.Services.Interface;

namespace ProyectoTicket.Services.Implementation
{
    public class TicketService : ITicketService
    {
        private List<Ticket> Tickets { get; set; } = [];
        public void Add(Ticket ticket)
        {
            Tickets.Add(ticket);
        }

        public bool Delete(int id)
        {
            int removedCount = Tickets.RemoveAll(t => t.Id == id);
            return removedCount > 0;
        }

        public List<Ticket> GetAll()
        {
            return Tickets;
        }
        public bool Update(int id, Ticket entity)
        {
            Ticket? ticket = Tickets.FirstOrDefault(t => t.Id == id);
            if (ticket != null)
            {
                ticket.Title = entity.Title;
                ticket.Description = entity.Description;
                ticket.Priority = entity.Priority;
                ticket.Status = entity.Status;
                return true;
            }
            return false;
        }
        public Ticket? GetById(int id)
        {
            Ticket? ticket = Tickets.FirstOrDefault(t => t.Id == id);
            if (ticket != null)
            {
                return ticket;
            }
            return null;
        }
    }
}