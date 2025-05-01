using System;
using ProyectoSolid.Interfaces;

namespace ProyectoSolid.Repository;

public class TaskRepository : ITaskRepository
{
	private readonly List<ITask> _tasks = new List<ITask>();

	public IEnumerable<ITask> GetAll()
	{
		return _tasks;
	}

	public ITask GetById(int id)
	{
		return _tasks.Find(task => task.Id == id);
	}

	public void Create(ITask task)
	{
		_tasks.Add(task);
	}

	public void Update(ITask task)
	{
		var index = _tasks.FindIndex(t => t.Id == task.Id);
		if (index != -1)
		{
			_tasks[index] = task;
		}
	}

	public void Delete(int id)
	{
		_tasks.RemoveAll(task => task.Id == id);
	}
}
