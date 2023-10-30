using System;
using System.ComponentModel;
using System.Threading.Channels;

namespace polis.tjuv2
{
    internal class Program
    {
        public static int numbersOfRobberies = 0;
        public static int numberOfArrest = 0;



        static void Main(string[] args)
        {
            List<Person> prison = new List<Person>(); // en lista för fängelset

            List<Person> city = new List<Person>(); // en lista med personer i staden

            for (int i = 0; i < 20; i++)
            {
                city.Add(new Police());
            }
            for (int c = 0; c < 20; c++)
            {
                city.Add(new Citizen());
            }
            for (int t = 0; t < 10; t++)
            {
                city.Add(new Thief());
            }


            int y = 25;
            int x = 100;

            char[,] matrix = new char[y, x];

            //Staden matris

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Console.Write(matrix[i, j] == '\0' ? ' ' : matrix[i, j]);

                }

                Console.WriteLine();
            }


            while (true)
            {

                Console.Clear();
                foreach (Person person in city)

                {

                    person.Move();
                    if (person is Citizen)
                    {
                        //Console.ForegroundColor = ConsoleColor.Green;
                        //Console.Write(person.GetType().Name + " " + person.Name + " " + person.TopPosition + " " + person.LeftPosition + " ");
                        //person.ShowList();
                        Console.SetCursorPosition(person.LeftPosition, person.TopPosition);
                        Console.Write(person.Character);

                    }
                    if (person is Police)
                    {
                        //Console.ForegroundColor = ConsoleColor.Blue;
                        Console.SetCursorPosition(person.LeftPosition, person.TopPosition);
                        Console.Write(person.Character);
                        //Console.Write(person.GetType().Name + " " + person.Name + " " + person.TopPosition + " " + person.LeftPosition + " ");
                        //person.ShowList();


                    }
                    if (person is Thief)
                    {
                        //Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(person.LeftPosition, person.TopPosition);
                        Console.Write(person.Character);

                        //Console.Write(person.GetType().Name + " " + person.Name + " " + person.TopPosition + " " + person.LeftPosition + " ");
                        //person.ShowList();
                        //Console.ResetColor();

                    }




                }
                for(int i = 0; i < city.Count; i++)
                {
                    CityPrison cityPrison = city[i].Meet(city, prison);
                    city = cityPrison.City;
                    prison = cityPrison.Prison;


                }


                //Fängelese matris
                int widht = 10;
                int height = 10;
                    
                Console.SetCursorPosition(0, 30);

                char[,] grid = new char[widht, height];

                for (int i = 0; i < widht; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (i == 0 || i == widht - 1 || j == 0 || j == height - 1)
                        {
                            grid[i, j] = '#'; //Väggar runt matrisen
                        }
                        else
                        {
                            grid[i, j] = ' '; // Lämna tomt inne i matrisen
                        }

                        Console.Write(grid[i, j] );


                    }

                    Console.WriteLine();
                }




                foreach (Person prisoner in prison)

                {
                    prisoner.Move();
                    Console.SetCursorPosition(prisoner.PrisonerLeftPosition, prisoner.PrisonerTopPosition);
                    Console.Write(prisoner.Character);
                }

                Console.SetCursorPosition(0, 41);
                Console.Write("Antal rånade medborgare: " + numbersOfRobberies);
                Console.WriteLine();
                Console.Write("Antal gripna tjuvar: " + numberOfArrest);

                Thread.Sleep(500);

            }


        }
    }
}