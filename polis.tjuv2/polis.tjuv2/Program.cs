﻿using System.ComponentModel;

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

            city.Add(new Person());
            city.Add(new Person());
            city.Add(new Person());
            while (true)
            {
                foreach (Person person in city)
                {
                    person.Move();
                    Console.WriteLine(person.TopPosition + " " + person.LeftPosition);
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}