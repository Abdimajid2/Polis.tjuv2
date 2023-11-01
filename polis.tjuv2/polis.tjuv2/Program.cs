using System;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace polis.tjuv2
{
    internal class Program
    {
        public static int numbersOfRobberies = 0;
        //public static int numberOfArrest = 0;   // Kan tas bort!!
        //public static int numberOfPoor = 0;     //Kan tas bort!!
     


        static void Main(string[] args)
        {
            List<Person> prison = new List<Person>(); // en lista för fängelset

            List<Person> city = new List<Person>(); // en lista med personer i staden

            List<Person> poorhouse = new List<Person>(); // lista för personer i fattighuset

            List<string> newsFeed = new List<string>();

            for (int i = 0; i < 20; i++)
            {
                city.Add(new Police());
            }
            for (int c = 0; c < 20; c++)
            {
                city.Add(new Citizen());
            }
            for (int t = 0; t < 30; t++)
            {
                city.Add(new Thief());
            }

            

            while (true) 
            {

                Console.Clear();

               //Staden
                int y = 25;
                int x = 100;

                char[,] matrix = new char[y, x];

                //Staden matris

                for (int i = 0; i <y; i++)
                {

                    for (int j = 0; j < x; j++)
                    {
                        if (i == 0 || i == y - 1 || j == 0 || j == x - 1)
                        {
                            matrix[i, j] = '#';
                        }
                        else
                        {
                            matrix[i, j] = ' ';
                        }
                        Console.Write(matrix[i, j]);
                        //Console.Write(matrix[i, j] == '\0' ? ' ' : matrix[i, j]);

                    }

                    Console.WriteLine();
                }

                foreach (Person person in city)

                {

                    person.Move();
                    if (person is Citizen)
                    {
                        //Console.ForegroundColor = ConsoleColor.Green;
                        
                        //(person.GetType().Name + " " + person.Name + " " + person.TopPosition + " " + person.LeftPosition + " ");
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
                    CityPrison cityPrison = city[i].Meet(city, prison,poorhouse,newsFeed);
                    city = cityPrison.City;
                    prison = cityPrison.Prison;
                    poorhouse = cityPrison.Poorhouse;
                    newsFeed = cityPrison.NewsFeed;
              
                }


                //Fängelese matris
                int height  = 10;
                int widht= 10;
                    
                Console.SetCursorPosition(0, 30);

                char[,] grid = new char [height, widht];

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < widht; j++)
                    {
                        if (i == 0 || i == height - 1 || j == 0 || j == widht - 1)
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
                int a = 10;
                int b = 50;

                Console.SetCursorPosition(0,41 );

                char[,] grids = new char[a, b];

                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        if (i == 0 || i == a - 1 || j == 0 || j == b - 1)
                        {
                            grids[i, j] = '#'; //Väggar runt matrisen
                        }
                        else
                        {
                            grids[i, j] = ' '; // Lämna tomt inne i matrisen
                        }

                        Console.Write(grids[i, j]);

                    }
                    Console.WriteLine();
                }
                foreach (Person poor in poorhouse)
                {
                    poor.Move();
                    Console.SetCursorPosition(poor.PoorLeftPosition, poor.PoorTopPosition);
                    Console.Write(poor.Character);
                }
                int index = 0;
                int removeNews = 0;
                for (int news = 0; news < 5; news++)
                {
                    if (newsFeed.Count - removeNews > news)
                    {
                        Console.SetCursorPosition(0, 56);
                        Console.WriteLine(newsFeed[news] + " ");
                    }
                    int breakpoint = 0;
                }

                Console.SetCursorPosition(0,52);
                Console.WriteLine("Antal rånade medborgare: " + numbersOfRobberies);
                Console.WriteLine("Antal gripna tjuvar: " + prison.Count);
                Console.WriteLine("Antal personer i fattighuset: " + poorhouse.Count);
                Console.WriteLine("Antal personer i staden: " + city.Count);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    switch (key.KeyChar)
                    {
                        case 'c':
                            city.Add(new Citizen());
                            break;
                        case 't':
                            city.Add(new Thief());
                            break;
                        case 'p':
                            city.Add(new Police());
                            break;
                    }
                }
                Thread.Sleep(1000);
                Console.CursorVisible = false;
                

            }
            


        }
    }
}