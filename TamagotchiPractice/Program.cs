using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagotchiPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog cachito = new Dog("Cachito");

            cachito.Play();
            Console.WriteLine(cachito.getName() + " has started to play");
            Console.ReadLine();

            cachito.Bark();
            Console.ReadLine();

            cachito.StopPlaying();
            Console.WriteLine(cachito.getName() + " just stoped playing");
            Console.ReadLine();

            Console.WriteLine(cachito.getName() + " age is " + cachito.getAge() + " days old");
            Console.ReadLine();
        }
    }
}
