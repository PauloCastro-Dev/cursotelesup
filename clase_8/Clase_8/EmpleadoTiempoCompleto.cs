using System;

namespace Clase_8;

public class EmpleadoTiempoCompleto : Empleado, IEmpleado
{
	public override void CalcularSalario()
	{
		Console.WriteLine("Calculando salario para empleado a tiempo completo: $3000.");
	}

	public void Trabajar()
	{
		Console.WriteLine("Empleado a tiempo completo trabajando.");
	}
}