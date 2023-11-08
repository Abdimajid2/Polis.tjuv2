using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;

namespace polis.tjuv2
{
    public class Thief : Person
    {
        Random random = new Random();
        public bool Prison { get; set; }

        public List<Item> StolenGoods { get; set; } // tjuvens lista


        public Thief()
        {


            List<Item> stolenGoods = new List<Item>(); // skapar en lista för tjuven där stulna sakerna förvaras

            StolenGoods = stolenGoods;

            Character = 'T'; //en bokstav som representerar tjuven i staden


        }

        public override CityPrison Meet(List<Person> city, List<Person> prison, List<Person> poorHouse, List<string> newsFeed) // SKICKADE IN LISTAN I METODEN
        {

            foreach (Person person in city)
            {
                if (TopPosition == person.TopPosition && this.LeftPosition == person.LeftPosition && this != person) // KOLLAR POSITIONERNA ÄR SAMMA OCH ATT MAN INTE KOLLAR PÅ SIG SJÄLV
                {
                    if (person is Citizen) // vad som hände när en tjuv möter en medborgare
                    {
                        Citizen citizen = (Citizen)person; // MÅSTE CASTA OM PERSON TILL EN CITIZEN FÖR ATT KOMMA ÅT SUBKLASS PROP


                        if (citizen.Belongings.Count > 0) // KOLLAR OM CITIZEN HAR BELONGINGS KVAR
                        {
                            int targetItem = random.Next(0, citizen.Belongings.Count); // randomeserar villket föremål tjuven tar från medborgaren
                            StolenGoods.Add(citizen.Belongings[targetItem]); // KOPERIAR CITIZENS BELONGING TILL THIEF LISTA
                            citizen.Belongings.RemoveAt(targetItem); // tar bort en sak från medborgarens lista
                            string stolenGoods = "";                           
                            foreach (Item item in StolenGoods)
                            {
                                stolenGoods += item.ItemName + ", ";                               
                            }
                            newsFeed.Add("Tjuven " + this.Name + " har rånat medborgaren " + citizen.Name + " på: " + stolenGoods /*+ hasStolen*/);
                            Console.SetCursorPosition(0, 27);
                            Program.numbersOfRobberies++;

                        }


                    }
                }
            }
            CityPrison cityPrison = new CityPrison();
            cityPrison.Prison = prison;
            cityPrison.City = city;
            cityPrison.PoorHouse = poorHouse;
            cityPrison.NewsFeed = newsFeed;
            return cityPrison;
        }
    }

}
