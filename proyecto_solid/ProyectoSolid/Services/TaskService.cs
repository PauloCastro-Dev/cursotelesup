using System;
using ProyectoSolid.Interfaces;

namespace ProyectoSolid.Services;

public class TaskService
{
	private readonly ITaskRepository _taskRepository;

	public TaskService(ITaskRepository taskRepository)
	{
		_taskRepository = taskRepository;
	}

	public IEnumerable<ITask> GetAllTasks()
	{
		return _taskRepository.GetAll();
	}

	public void AddTask(ITask task)
	{
		_taskRepository.Create(task);
	}

	public void CompleteTask(int id)
	{
		var task = _taskRepository.GetById(id);
		if (task != null)
		{
			task.Completed = true;
			_taskRepository.Update(task);
		}
	}
}