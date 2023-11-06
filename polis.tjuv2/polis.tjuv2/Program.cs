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
        static void Main(string[] args)
        {
            List<Person> prison = new List<Person>(); // en lista för fängelset

            List<Person> city = new List<Person>(); // en lista med personer i staden

            List<Person> poorhouse = new List<Person>(); // lista för personer i fattighuset

            List<string> newsFeed = new List<string>();
            
            for (int i = 0; i < 20; i++) //Antal personer i staden från början.
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
                Console.WriteLine("================================================CITY================================================");
                Console.SetCursorPosition(0, 1);
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
                    }
                    Console.WriteLine();
                }

                foreach (Person person in city)

                {
                    person.Move();
                    if (person is Citizen)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        //(person.GetType().Name + " " + person.Name + " " + person.TopPosition + " " + person.LeftPosition + " ");
                        //person.ShowList();
                        Console.SetCursorPosition(person.LeftPosition, person.TopPosition);
                        Console.Write(person.Character);
                        Console.ResetColor();

                    }
                    if (person is Police)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.SetCursorPosition(person.LeftPosition, person.TopPosition);
                        Console.Write(person.Character);
                        //Console.Write(person.GetType().Name + " " + person.Name + " " + person.TopPosition + " " + person.LeftPosition + " ");
                        //person.ShowList();                    
                        Console.ResetColor();
                    }
                    if (person is Thief)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(person.LeftPosition, person.TopPosition);
                        Console.Write(person.Character);
                        //Console.Write(person.GetType().Name + " " + person.Name + " " + person.TopPosition + " " + person.LeftPosition + " ");
                        //person.ShowList();
                        Console.ResetColor();
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
                 
                Console.SetCursorPosition(0, 27);
                Console.WriteLine("==PRISON==");
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    prisoner.Move();
                    Console.SetCursorPosition(prisoner.PrisonerLeftPosition, prisoner.PrisonerTopPosition);
                    Console.Write(prisoner.Character);
                    Console.ResetColor();
                }

                //PoorHouse matris
                int a = 10;
                int b = 50;
                                
                Console.SetCursorPosition(0,39 );
                Console.WriteLine("===================POORHOUSE=====================");

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
                    Console.ForegroundColor = ConsoleColor.Green;
                    poor.Move();
                    Console.SetCursorPosition(poor.PoorLeftPosition, poor.PoorTopPosition);
                    Console.Write(poor.Character);
                    Console.ResetColor();
                }
                
                //Newsfeed
                
                int indexremoveNews = 0;                
                Console.SetCursorPosition(0, 58);
                
                for (int news = 0; news < 5; news++)
                {
                    
                    if (newsFeed.Count - indexremoveNews > news)
                    {
                      
                        Console.Write(newsFeed[news] + " ");
                        if (newsFeed.Count >5 ) 
                        {
                            newsFeed.RemoveAt(0);
                        }
                        Console.WriteLine();
                    }
                   
                }
                Console.WriteLine("==================================================");

                Console.SetCursorPosition(0,51);
                Console.WriteLine("======================STATUS======================");
                Console.WriteLine("Antal rånade medborgare: " + numbersOfRobberies);
                Console.WriteLine("Antal gripna tjuvar: " + prison.Count);
                Console.WriteLine("Antal personer i fattighuset: " + poorhouse.Count);
                Console.WriteLine("Antal personer i staden: " + city.Count);
               
                if (Console.KeyAvailable) //Lägger till personer, tjuvar och poliser.
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

                Console.WriteLine ("======================NEWS FEED===================");               
                Thread.Sleep(500);
                Console.CursorVisible = false;                

            }       
        }
    }
}