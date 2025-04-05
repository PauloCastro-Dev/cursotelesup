// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
int i = 1;
while (i <= 5)
{
    int j = 1;
    while (j <= 5)
    {
        if (j <= i)
        {
            Console.Write(j + " ");
        }
        else
        {
            Console.Write("* ");
        }
        j++;
    }
    Console.WriteLine();
    i++;
}