using ProyectoSolid.Controller;
using ProyectoSolid.Interfaces;
using ProyectoSolid.Repository;
using ProyectoSolid.Services;

namespace ProyectoSolid
{
	class Program
	{
		static void Main(string[] args)
		{

			/*
			1.Single Responsibility Principle(SRP) -Principio de Responsabilidad Única

			Task: Representa el modelo de datos de una tarea.
			TaskRepository: Gestiona el acceso a los datos de las tareas.
			TaskService: Contiene la lógica de negocio relacionada con las tareas, como marcarlas como completadas.
			TaskController: Actúa como intermediario entre la lógica de negocio y la interfaz de usuario.
			*/

			/*
			2. Open/Closed Principle (OCP) - Principio Abierto/Cerrado
			Interfaces (ITask, ITaskRepository): Permiten extender el comportamiento del sistema sin modificar las clases existentes.
			*/

			/*
			3. Liskov Substitution Principle (LSP) - Principio de Sustitución de Liskov
			TaskRepository implementa ITaskRepository, lo que garantiza que cualquier clase que dependa de ITaskRepository (como TaskService) pueda usar cualquier implementación concreta de esta interfaz sin problemas.
			*/

			/*
			4. Interface Segregation Principle (ISP) - Principio de Segregación de Interfaces
			Las interfaces están diseñadas para ser específicas y no obligan a las clases a implementar métodos que no necesitan:
			ITask: Define únicamente las propiedades necesarias para una tarea.
			ITaskRepository: Define métodos específicos para la gestión de tareas (CRUD). Esto asegura que las clases que implementan estas interfaces no tengan métodos innecesarios.
			*/

			/*
			5. Dependency Inversion Principle (DIP) - Principio de Inversión de Dependencias
			TaskService depende de la abstracción ITaskRepository en lugar de depender directamente de TaskRepository. Esto permite cambiar la implementación del repositorio sin afectar la lógica de negocio.
			*/


			Console.WriteLine("Hello, World!");

			ITaskRepository taskRepository = new TaskRepository();
			TaskService taskService = new(taskRepository);
			TaskController taskController = new(taskService);


			taskController.CreateTask(1, "Tarea 1", "Descripción de la tarea 1");
			taskController.CreateTask(2, "Tarea 2", "Descripción de la tarea 2");

			taskController.ListTasks();

			taskController.MarkTaskAsCompleted(1);
			taskController.ListTasks();
		}
	}
}