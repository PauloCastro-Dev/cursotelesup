using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoTicket.Models;
using ProyectoTicket.Models.Enums;
using ProyectoTicket.Services.Interface;

namespace ProyectoTicket.Services
{
    public class TicketMenuService(ITicketService ticketService, UiService uiService)
    {
        private readonly ITicketService _ticketService = ticketService;
        private readonly UiService _uiService = uiService;
        public void ShowTicketMenu()
        {
            Console.WriteLine("Gestión de Tickets");
            Console.WriteLine("1. Crear Ticket");
            Console.WriteLine("2. Ver Tickets");
            Console.WriteLine("3. Actualizar Ticket");
            Console.WriteLine("4. Eliminar Ticket");
            Console.WriteLine("5. Volver al menú principal");
            Console.Write("Seleccione una opción: ");
            string option = Console.ReadLine() ?? string.Empty;
            switch (option)
            {
                case "1":
                    AddTicket();
                    break;
                case "2":
                    GetAllTickets();
                    break;
                case "3":
                    UpdateTicket();
                    break;
                case "4":
                    DeleteTicket();
                    break;
                case "5":
                    _uiService.ShowMainMenu();
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    ShowTicketMenu();
                    break;
            }
        }

        public void AddTicket()
        {
            Console.WriteLine("Creando un nuevo ticket...");
            Console.Write("Ingrese el título del ticket: ");
            string title = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese la descripción del ticket: ");
            string description = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese la prioridad del ticket (1 = Baja, 2 = Media, 3 = Alta): ");
            string priorityInput = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(priorityInput, out int priority) || priority < 1 || priority > 3)
            {
                Console.WriteLine("Prioridad no válida. Debe ser un número entre 1 y 3.");
                return;
            }
            _ticketService.Add(new Ticket { Title = title, Description = description, Priority = (Priority)priority });
            Console.WriteLine("Ticket creado con éxito.");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            _uiService.ShowMainMenu();
        }
        public void GetAllTickets()
        {
            List<Ticket> tickets = _ticketService.GetAll();
            if (tickets.Count == 0)
            {
                Console.WriteLine("No hay tickets disponibles.");
                return;
            }
            Console.WriteLine("Lista de Tickets:");
            foreach (var ticket in tickets)
            {
                Console.WriteLine($"ID: {ticket.Id}, Título: {ticket.Title}, Descripción: {ticket.Description}, Prioridad: {ticket.Priority}");
            }
        }
        public void UpdateTicket()
        {
            Console.Write("Ingrese el ID del ticket a actualizar: ");
            string idInput = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(idInput, out int id))
            {
                Console.WriteLine("ID no válido. Debe ser un número.");
                return;
            }
            Ticket? ticket = _ticketService.GetById(id);
            if (ticket == null)
            {
                Console.WriteLine("Ticket no encontrado.");
                return;
            }
            Console.Write("Ingrese el nuevo título del ticket: ");
            string title = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese la nueva descripción del ticket: ");
            string description = Console.ReadLine() ?? string.Empty;
            Console.Write("Ingrese la nueva prioridad del ticket (1 = Baja, 2 = Media, 3 = Alta): ");
            string priorityInput = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(priorityInput, out int priority) || priority < 1 || priority > 3)
            {
                Console.WriteLine("Prioridad no válida. Debe ser un número entre 1 y 3.");
                return;
            }
            _ticketService.Update(id, new Ticket { Title = title, Description = description, Priority = (Priority)priority });
        }
        public void DeleteTicket()
        {
            Console.Write("Ingrese el ID del ticket a eliminar: ");
            string idInput = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(idInput, out int id))
            {
                Console.WriteLine("ID no válido. Debe ser un número.");
                return;
            }
            _ticketService.Delete(id);
        }
    }
}