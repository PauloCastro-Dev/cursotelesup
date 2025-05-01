using System;
using ProyectoSolid.Interfaces;

namespace ProyectoSolid.Models;

public class Task : ITask
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public bool Completed { get; set; } = false;
}