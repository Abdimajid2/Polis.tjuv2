using System;
using System.ComponentModel;

namespace polis.tjuv2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int policeNmr = 10;
            int citizenNmr = 30;
            int criminalNmr = 20;


            List<Person> city = new List<Person>();

            for (int i = 0; i < 5; i++)
            {
                city.Add(new Police());
            }
            for (int c = 0; c < 10; c++)
            {
                city.Add(new Citizen());
            }
            for (int t = 0; t < 10; t++)
            {
                city.Add(new Thief());
            }


            int y = 25;
            int x = 100;
            int numberOfPCharacters = 10;
            int numberOfCCharacters = 10;

            char[,] matrix = new char[y, x];
            //Random random = new Random();
            for (int pcount = 0; pcount < numberOfPCharacters; pcount++)
            {
                //int randomRow = random.Next(0, y);
                //int randomCol = random.Next(0, x);
                //matrix[randomRow, randomCol] = 'n';


            }


            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Console.Write(matrix[i, j] == '\0' ? ' ' : matrix[i, j]);

                }

                Console.WriteLine();
            }
            //Fylla med 10 poliser








            
            while (true)
            {

                Console.Clear();
                foreach (Person person in city)

                {

                    person.Move();
                    if (person is Citizen)
                    {
                        ////Console.Write(person.GetType().Name + " " + person.Name + " " + person.TopPosition + " " + person.LeftPosition + " ");
                        //person.ShowList();
                        Console.SetCursorPosition(person.LeftPosition, person.TopPosition);
                        Console.Write(person.Character);

                    }
                    if (person is Police)
                    {
                        Console.SetCursorPosition(person.LeftPosition, person.TopPosition);
                        Console.Write(person.Character);
                        //Console.Write(person.GetType().Name + " " + person.Name + " " + person.TopPosition + " " + person.LeftPosition + " ");
                        //person.ShowList();


                    }
                    if (person is Thief)
                    {
                        Console.SetCursorPosition(person.LeftPosition, person.TopPosition);
                        Console.Write(person.Character);
                        //Console.Write(person.GetType().Name + " " + person.Name + " " + person.TopPosition + " " + person.LeftPosition + " ");
                        //person.ShowList();


                    }
                    int g = 0;



                }
                foreach (Person person in city)
                {
                    person.Meet(city);

                }



                Thread.Sleep(1); // GJORDE EN ANNAN UPPDATERINGSMETOD
                //Console.ReadKey();
                //Console.Clear();
            }
        }
    }
}