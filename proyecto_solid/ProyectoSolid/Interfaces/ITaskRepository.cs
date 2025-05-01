using System;

namespace ProyectoSolid.Interfaces;
public interface ITaskRepository
{
	IEnumerable<ITask> GetAll();
	ITask GetById(int id);
	void Create(ITask task);
	void Update(ITask task);
	void Delete(int id);
}
