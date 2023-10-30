using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polis.tjuv2
{
    public class Police : Person
    {

        public List<Item> Confiscated { get; set; } // polisens lista 
  
        public Police()
        {
            List<Item> confiscated = new List<Item>(); // skapar en lista för polisen där sakerna som har tagits från tjuven förvaras

            Confiscated = confiscated;

            Character = 'P'; //en bokstav som representerar polis i staden

             
        }

        public override void ShowList()
        {
            foreach (Item item in Confiscated)
            {
                Console.Write(item.ItemName + " ");
            }

        }
         
        public override CityPrison Meet(List<Person> city, List<Person> prison) // skickade in listan med personer i metoden
        {
            foreach (Person person in city) // loopar personerna i staden
            {
                if (TopPosition == person.TopPosition && LeftPosition == person.LeftPosition && this != person) // KOLLAR POSITIONERNA ÄR SAMMA OCH ATT MAN INTE KOLLAR PÅ SIG SJÄLV
                {

                    if (person is Thief) // vad som händer när en polis möter på en tjuv
                    {

                         
                        Thief thief = (Thief)person; // vad som händer när en polis möter på en tjuv

                        if (thief.StolenGoods.Count > 0)
                        {
                            
                              
                            city.Remove(thief);
                            prison.Add(thief);
                            
                            Confiscated.AddRange(thief.StolenGoods); // polisen kopierar hela tjuvens lista
                            Console.SetCursorPosition(0, 27);
                            Console.Write("Polisen har fångat en tjuv som hade tagit ");
                            ShowList();
                            Console.WriteLine();
                            thief.StolenGoods.Clear(); // polisen tömmer hela tjuvens lista
                            Program.numberOfArrest++;
                            Move();
                            
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            Move(); /*om polis möter på en annan polis kommer den att flytta på sig*/
                        }
                    }
                    if(person is Citizen)
                    {
                        Move();
                    }
                   

                }

            }
            CityPrison cityPrison = new CityPrison();
            cityPrison.Prison = prison;
            cityPrison.City = city;
            return cityPrison;
        }

    }
}