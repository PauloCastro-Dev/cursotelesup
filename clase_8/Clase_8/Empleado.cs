using System;

namespace Clase_8;

public abstract class Empleado
{
	public string? Nombre { get; set; }
	public abstract void CalcularSalario();
}