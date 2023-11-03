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
        public override CityPrison Meet(List<Person> city, List<Person> prison, List<Person> poorhouse, List<string> newsFeed) // skickade in listan med personer i metoden
        {   
            int removePerson = 0;
            for(int i = 0; i <city.Count-removePerson-1; i++) // loopar personerna i staden
            {
                if (city.Count - removePerson > i)
                {
                    if (TopPosition == city[i].TopPosition && LeftPosition == city[i].LeftPosition && this != city[i]) // KOLLAR POSITIONERNA ÄR SAMMA OCH ATT MAN INTE KOLLAR PÅ SIG SJÄLV
                    {

                        if (city[i] is Thief) // vad som händer när en polis möter på en tjuv
                        {
                            Thief thief = (Thief)city[i]; // vad som händer när en polis möter på en tjuv

                            if (thief.StolenGoods.Count > 0)
                            {
                               
                                removePerson++;

                                city.Remove(thief);
                                prison.Add(thief);

                                Confiscated.AddRange(thief.StolenGoods); // polisen kopierar hela tjuvens lista
                                string confiscated = "";
                                foreach (Item item in Confiscated)
                                {
                                   confiscated += item.ItemName + ", ";
                                }
                                newsFeed.Add("Polisen " + this.Name + " har fångat en tjuv " + thief.Name + " som hade tagit: " + confiscated);
                                Console.WriteLine();
                                thief.StolenGoods.Clear(); // polisen tömmer hela tjuvens lista
                                                           //Program.numberOfArrest++;  //Kan tas bort!!
                                                           //    Move();


                            }
                            //else
                            //{
                            //    Move(); /*om polis möter på en annan polis kommer den att flytta på sig*/
                            //}
                        }
                        if (city[i] is Citizen)
                        {
                            Citizen citizen = (Citizen)city[i];
                            if (citizen.Belongings.Count == 0)
                            {
                                city.Remove(citizen); 
                                poorhouse.Add(citizen);
                                newsFeed.Add("Polisen har träffat en medborgaren "+ citizen.Name+" utan ägodelar, tar personen till fattighuset");
                                
                             //Program.numberOfPoor++;  //Kan tas bort!!
                                //Move();
                                Thread.Sleep(1000);
                            }

                        }


                    }
                }
            }
            CityPrison cityPrison = new CityPrison();
            cityPrison.Prison = prison;
            cityPrison.City = city;
            cityPrison.Poorhouse = poorhouse;
            cityPrison.NewsFeed = newsFeed;
            return cityPrison;
        }

    }
}