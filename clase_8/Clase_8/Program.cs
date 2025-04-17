// See https://aka.ms/new-console-template for more information
using Clase_8;

Console.WriteLine("Hello, World!");
Gato gato = new Gato();
gato.animalSound();
Console.WriteLine(gato.contarEdar(5));

EmpleadoTiempoCompleto empleado = new EmpleadoTiempoCompleto();
empleado.Trabajar();
empleado.CalcularSalario();

EmpleadoMedioTiempo empleadoMedioTiempo = new EmpleadoMedioTiempo();
empleadoMedioTiempo.Trabajar();
empleadoMedioTiempo.CalcularSalario();

Console.ReadKey();