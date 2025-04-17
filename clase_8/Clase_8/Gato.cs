using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clase_8
{
    public class Gato : IAnimal
    {
        public void animalSound()
        {
            Console.WriteLine("El gato hace miau");
        }

        public int contarEdar(int edad)
        {
            return edad * 7;
        }

    }
}