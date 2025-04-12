Console.WriteLine("==================");
Console.WriteLine("Repaso bucles");
/*
 * *
 * * *
 * * * *
 * * * * *
 */

// For loop:
/*int i, j, filas;
Console.WriteLine("Ingresa el numero de filas");
filas = Convert.ToInt32(Console.ReadLine());

for (i = 1; i <= filas; i++)
{
    for (j = 1; j <= i; j++)
    {
        Console.Write("* ");
    }
    Console.Write("\n");
}
Console.WriteLine("Se acabo el bucle");
*/

/*int i, j, filas;
Console.WriteLine("Ingresa el numero de filas");
filas = Convert.ToInt32(Console.ReadLine());

for (i = 1; i <= filas; i++)
{
    for (j = 1; j <= i; j++)
    {
        Console.Write(j);
    }
    Console.Write("\n");
}*/



int filas;
Console.WriteLine("Ingresa el número de filas para la pirámide:");
filas = Convert.ToInt32(Console.ReadLine());

for (int i = 1; i <= filas; i++)
{

    for (int j = 1; j <= filas - i; j++)
    {
        Console.Write(" ");
    }


    for (int k = 1; k <= (2 * i - 1); k++)
    {
        Console.Write("*");
    }

    Console.WriteLine();
}

