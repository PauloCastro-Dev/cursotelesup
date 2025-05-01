using System;
using ProyectoSolid.Services;
using ProyectoSolid.Models;
namespace ProyectoSolid.Controller;

public class TaskController
{
	private readonly TaskService _taskService;

	public TaskController(TaskService taskService)
	{
		_taskService = taskService;
	}

	public void ListTasks()
	{
		var tasks = _taskService.GetAllTasks();
		foreach (var task in tasks)
		{
			Console.WriteLine($"ID: {task.Id}, Title: {task.Title}, Completed: {task.Completed}");
		}
	}

	public void CreateTask(int id, string title, string description)
	{
		var task = new ProyectoSolid.Models.Task { Id = id, Title = title, Description = description };
		_taskService.AddTask(task);
		Console.WriteLine("Tarea creada.");
	}

	public void MarkTaskAsCompleted(int id)
	{
		_taskService.CompleteTask(id);
		Console.WriteLine($"La tarea con el ID {id} fue marcada como completada.");
	}
}
