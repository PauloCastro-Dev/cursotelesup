using ProyectoTicket.Services;
using ProyectoTicket.Services.Implementation;
using ProyectoTicket.Services.Interface;
class Program
{
	static void Main(string[] args)
	{
		IDeveloperService developerService = new DeveloperService();
		ITicketService ticketService = new TicketService();
		ICommentService commentService = new CommentService();
		TicketMenuService ticketMenuService = new TicketMenuService(ticketService, new UiService(developerService, ticketService, commentService));
		Console.WriteLine("Bienvenido al sistema de gestión de tickets.");
		ticketMenuService.ShowTicketMenu();
	}
}