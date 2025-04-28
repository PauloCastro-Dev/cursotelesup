using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoTicket.Models;
using ProyectoTicket.Services.Interface;

namespace ProyectoTicket.Services
{
    public class UiService
    {
        private readonly IDeveloperService _developerService;
        private readonly ITicketService _ticketService;
        private readonly ICommentService _commentService;
        private readonly TicketMenuService _ticketMenuService;

        public UiService(IDeveloperService developerService, ITicketService ticketService, ICommentService commentService)
        {
            _developerService = developerService;
            _ticketService = ticketService;
            _commentService = commentService;
            _ticketMenuService = new TicketMenuService(ticketService, this);
        }

        public void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("Bienvenido al sistema de gestión de tickets.");
            Console.WriteLine("1. Gestion Ticket");
            Console.WriteLine("2. Gestion de Usuarios");
            Console.WriteLine("3. Gestion de Comentarios");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            string option = Console.ReadLine() ?? string.Empty;
            switch (option)
            {
                case "1":
                    _ticketMenuService.ShowTicketMenu();
                    break;
                case "2":
                    ShowUserMenu();
                    break;
                case "3":
                    ShowCommentMenu();
                    break;
                case "4":
                    Console.WriteLine("Saliendo del sistema...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    ShowMainMenu();
                    break;
            }
        }
        public void ShowUserMenu()
        {
            Console.WriteLine("Gestión de Usuarios");
            Console.WriteLine("1. Crear Usuario");
            Console.WriteLine("2. Ver Usuarios");
            Console.WriteLine("3. Actualizar Usuario");
            Console.WriteLine("4. Eliminar Usuario");
            Console.WriteLine("5. Volver al menú principal");
            Console.Write("Seleccione una opción: ");
            string option = Console.ReadLine() ?? string.Empty;
            switch (option)
            {
                case "1":
                    // Crear usuario
                    break;
                case "2":
                    // Ver usuarios
                    break;
                case "3":
                    // Actualizar usuario
                    break;
                case "4":
                    // Eliminar usuario
                    break;
                case "5":
                    ShowMainMenu();
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    ShowUserMenu();
                    break;
            }
        }
        public void ShowCommentMenu()
        {
            Console.WriteLine("Gestión de Comentarios");
            Console.WriteLine("1. Crear Comentario");
            Console.WriteLine("2. Ver Comentarios");
            Console.WriteLine("3. Actualizar Comentario");
            Console.WriteLine("4. Eliminar Comentario");
            Console.WriteLine("5. Volver al menú principal");
            Console.Write("Seleccione una opción: ");
            string option = Console.ReadLine() ?? string.Empty;
            switch (option)
            {
                case "1":
                    // Crear comentario
                    break;
                case "2":
                    // Ver comentarios
                    break;
                case "3":
                    // Actualizar comentario
                    break;
                case "4":
                    // Eliminar comentario
                    break;
                case "5":
                    ShowMainMenu();
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    ShowCommentMenu();
                    break;
            }
        }
    }
}