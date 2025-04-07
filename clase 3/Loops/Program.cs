// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// Patron usando while
Console.WriteLine("Patron usando while:");
int i = 1;
while (i <= 5)
{
    int j = 1;
    while (j <= i)
    {
        Console.Write(j + " ");
        j++;
    }
    Console.WriteLine();
    i++;
}
// Tabla de multiplicacion de un numero
Console.WriteLine("Ingresar numero:");
int number = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"Multiplication table for {number}:");

for (int i = 1; i <= 12; i++)
{
    Console.WriteLine($"{number} x {i} = {number * i}");
}



//Patron de numero usando un for
Console.WriteLine("Patron usando for:");

for (int i = 1; i <= 5; i++)
{
    for (int j = 1; j <= i; j++)
    {
        Console.Write(j + " ");
    }
    Console.WriteLine();
}