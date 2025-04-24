using ProyectoSistemaTareas;

class Program
{
	static void Main(string[] args)
	{
		SistemaTareas sistemaTareas = new SistemaTareas();
		bool salir = false;

		while (!salir)
		{
			Console.WriteLine("\nSistema de Gestión de Tareas");
			Console.WriteLine("1. Agregar Tarea");
			Console.WriteLine("2. Listar Tareas");
			Console.WriteLine("3. Listar Tareas Pendientes");
			Console.WriteLine("4. Listar Tareas Completadas");
			Console.WriteLine("5. Completar Tarea");
			Console.WriteLine("6. Editar Tarea");
			Console.WriteLine("7. Eliminar Tarea");
			Console.WriteLine("8. Salir");
			Console.Write("Seleccione una opción: ");

			var opcion = Console.ReadLine();

			switch (opcion)
			{
				case "1":
					Console.Write("Descripción de la tarea: ");
					var descripcion = Console.ReadLine() ?? string.Empty;
					Console.Write("Prioridad (Alta = 1, Media = 2, Baja = 3): ");
					var prioridad = int.TryParse(Console.ReadLine(), out int prioridadValue) ? prioridadValue : 0;
					if (prioridad < 1 || prioridad > 3)
					{
						Console.WriteLine("Prioridad inválida. Debe ser entre 1 y 3.");
						break;
					}
					sistemaTareas.AgregarTarea(descripcion, prioridad);
					break;

				case "2":
					Console.WriteLine("\nTareas:");
					sistemaTareas.ListarTareas();
					break;

				case "3":
					Console.WriteLine("\nTareas Pendientes:");
					sistemaTareas.ListarTareasPendientes();
					break;

				case "4":
					Console.WriteLine("\nTareas Completadas:");
					sistemaTareas.ListarTareasCompletadas();
					break;

				case "5":
					Console.Write("ID de la tarea a completar: ");
					if (int.TryParse(Console.ReadLine(), out int idCompletar))
					{
						sistemaTareas.CompletarTarea(idCompletar);
					}
					else
					{
						Console.WriteLine("ID inválido.");
					}
					break;

				case "6":
					Console.Write("ID de la tarea a editar: ");
					if (int.TryParse(Console.ReadLine(), out int idEditar))
					{
						Console.Write("Nueva descripción: ");
						var nuevaDescripcion = Console.ReadLine() ?? string.Empty;
						Console.Write("Nueva prioridad (Alta = 1, Media = 2, Baja = 3): ");
						int nuevaPrioridad = int.TryParse(Console.ReadLine(), out int prioridadValueEdit) ? prioridadValueEdit : 0;
						if (nuevaPrioridad < 1 || nuevaPrioridad > 3)
						{
							Console.WriteLine("Prioridad inválida. Debe ser entre 1 y 3.");
							break;
						}
						sistemaTareas.EditarTarea(idEditar, nuevaDescripcion, nuevaPrioridad);
					}
					else
					{
						Console.WriteLine("ID inválido.");
					}
					break;

				case "7":
					Console.Write("ID de la tarea a eliminar: ");
					if (int.TryParse(Console.ReadLine(), out int idEliminar))
					{
						sistemaTareas.EliminarTarea(idEliminar);
					}
					else
					{
						Console.WriteLine("ID inválido.");
					}
					break;

				case "8":
					salir = true;
					Console.WriteLine("Saliendo del sistema...");
					break;

				default:
					Console.WriteLine("Opción no válida.");
					break;
			}
		}
	}
}