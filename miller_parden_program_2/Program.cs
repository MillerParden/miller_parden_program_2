using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miller_parden_program_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hare hare = new Hare("Hare", 'H');

            Tortoise tortoise = new Tortoise("Tortoise", 'T');

            Race race = new Race(hare, tortoise);

            race.Simulate();
        }
    }
}
