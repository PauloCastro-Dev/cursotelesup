using System;

namespace Clase_8;

public class EmpleadoMedioTiempo : Empleado, IEmpleado
{
	public override void CalcularSalario()
	{
		Console.WriteLine("Calculando salario para empleado a medio tiempo: $1500");
	}

	public void Trabajar()
	{
		Console.WriteLine("Empleado a medio tiempo trabajando.");
	}
}