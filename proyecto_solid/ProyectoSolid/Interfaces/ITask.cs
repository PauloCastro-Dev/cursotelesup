using System;

namespace ProyectoSolid.Interfaces;

public interface ITask
{
	int Id { get; set; }
	string Title { get; set; }
	string Description { get; set; }
	bool Completed { get; set; }
}
