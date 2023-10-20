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

            city.Add(new Thief());
            city.Add(new Citizen());
            city.Add(new Police());
            city.Add(new Thief());
            city.Add(new Citizen());
            city.Add(new Police());
            city.Add(new Thief());
            city.Add(new Citizen());
            city.Add(new Police());
            city.Add(new Thief());
            city.Add(new Citizen());
            city.Add(new Police());
            city.Add(new Thief());
            city.Add(new Citizen());
            city.Add(new Police());
            city.Add(new Thief());
            city.Add(new Citizen());
            city.Add(new Police());


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

            
                
                
               
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}