using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace miller_parden_program_2
{
    internal abstract class RaceAnimal
    {
        private char[] track = new char[70];
        private int position;
        private char symbol;
        public string Name;

        public int GetPosition()
        {
            return position;
        }


        public RaceAnimal(string name, char symbol)
        {

            this.position = 0;

            this.symbol = symbol;

            this.Name = name;

            for (int i = 0; i < track.Length; i++)
            {
                if (i == position)
                {
                    track[i] = symbol;
                }
                else
                {
                    track[i] = '-';
                }
            }




        }

        public override string ToString()
        {
            return new string(track);
        }

        protected void ChangePos(int steps)
        {

            int MovedPosition = position + steps;

            if (MovedPosition >= 0 && MovedPosition < track.Length)
            {
                track[position] = '-';


                position = MovedPosition;



                track[position] = symbol;
            }



        }

        public abstract void Move();


    }


    internal class Hare : RaceAnimal
    {
        public Hare(string name, char symbol) : base(name, symbol)
        {

        }

        public override void Move()
        {
            int move = GetRandomNumber();



            if (move == 1 || move == 2)
            {
                ChangePos(0);
            }
            else if (move == 3 || move == 4)
            {

                ChangePos(9);
            }
            else if (move == 5)
            {

                ChangePos(-12);
            }
            else if (move == 6 || move == 7 || move == 8)
            {
                ChangePos(1);
            }
            else
            {
                ChangePos(-2);

            }

        }

        private int GetRandomNumber()
        {
            Random random = new Random();
            return random.Next(1, 11);
        }
    }



    internal class Torotise : RaceAnimal
    {
        public Torotise(string name, char symbol) : base(name, symbol)
        {

        }

        public override void Move()
        {
            int move = GetRandomNumber();


            if (move == 1 || move == 2 || move == 3 || move == 4 || move == 5)
            {
                ChangePos(3);
            }
            else if (move == 6 || move == 7)
            {
                ChangePos(-6);
            }
            else
            {
                ChangePos(1);

            }

        }

        private int GetRandomNumber()
        {
            Random random = new Random();
            return random.Next(1, 11);
        }
    }


    internal class Race
    {

        private RaceAnimal animal1;
        private RaceAnimal animal2;
        private RaceAnimal winner;
        bool over;


        public Race(RaceAnimal Hare, RaceAnimal Torotise)
        {
            this.animal1 = Hare;


            this.animal2 = Torotise;


            winner = null;

            over = false;
        }

        public void UpdateStatus()
        {

            int pos1 = animal1.GetPosition();

            int pos2 = animal2.GetPosition();

            if (pos1 == 69 && pos2 == 69)
            {
                winner = null;
                over = true;
            }
            else if (pos1 == 69)
            {
                winner = animal1;
                over = true;
            }
            else if (pos2 == 69)
            {
                winner = animal2;
                over = true;
            }
        }


        public void Simulate()
        {
            Console.WriteLine($"Begining the race between {animal1.Name} and {animal2.Name}!");

            while (!over)

            {
                animal1.Move();

                animal2.Move();

                Console.WriteLine(animal1);

                Console.WriteLine(animal2);

                Thread.Sleep(1000);

                Console.Clear();

                UpdateStatus();
            }

            if (winner == null)
            {
                Console.WriteLine("A tie has happen hurray!");
            }
            else
            {
                Console.WriteLine($"The winner is {winner.Name}!");
            }
        }
    }













}



