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

            for (int i = 0; i < 10; i++)
            {
                city.Add(new Police());
            }
            for (int c = 0; c < 10; c++)
            {
                city.Add(new Citizen());
            }
            for(int t = 0; t < 10; t++)
            {
                city.Add(new Thief());
            }
            


            while (true)
            {


                foreach (Person person in city)

                {

                    person.Move();
                    if (person is Citizen)
                    {
                        Console.Write(person.GetType().Name + " " + person.TopPosition + " " + person.LeftPosition + " ");
                        person.ShowList();
                        Console.WriteLine();
                    }
                    if (person is Police)
                    {
                        Console.Write(person.GetType().Name + " " + person.TopPosition + " " + person.LeftPosition + " ");
                        person.ShowList();
                        Console.WriteLine();
                    }
                    if (person is Thief)
                    {
                        Console.Write(person.GetType().Name + " " + person.TopPosition + " " + person.LeftPosition + " ");
                        person.ShowList();
                        Console.WriteLine();
                    }
                    //Console.WriteLine(person.GetType().Name + " " + person.TopPosition + " " + person.LeftPosition + " "); 


                    int x = 0;
                }
                foreach (Person person in city)
                {
                    person.Meet(city);

                }



                Thread.Sleep(100); // GJORDE EN ANNAN UPPDATERINGSMETOD
                //Console.ReadKey();
                Console.Clear();
            }
        }
    }
}