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

        public List<Item> Confiscated { get; set; }

        public Police()
        {
            List<Item> confiscated = new List<Item>();

            Confiscated = confiscated;


        }

        public override void ShowList()
        {
            foreach (Item item in Confiscated)
            {
                Console.Write(item.ItemName + " ");
            }
  
        }

        public override void Meet(List<Person> city) // SKICKADE IN LISTAN I METODEN
        {
            foreach (Person person in city)
            {
                if (this.TopPosition == person.TopPosition && this.LeftPosition == person.LeftPosition && this != person) // KOLLAR POSITIONERNA ÄR SAMMA OCH ATT MAN INTE KOLLAR PÅ SIG SJÄLV
                {
                    //Console.WriteLine("tjuv har träffat en person");
                    if (person is Thief)
                    {
                        //Console.WriteLine("det är en tjuv");

                        Thief thief = (Thief)person;

                        if (thief.StolenGoods.Count > 0)
                        {

                             Confiscated.AddRange(thief.StolenGoods); // polisen kopierar hela tjuvens lista


                            thief.StolenGoods.Clear(); // polisen tömmer hela tjuvens lista
                            //Console.WriteLine("polisen träffar tjuven och tar hans grejer");
                        }
                    }
                    else if (person is Citizen)
                    {
                        //Console.WriteLine("det är en medborgare");

                    }
                    else if (person is Police)
                    {
                        //Console.WriteLine("det är en polis");
                    }

                }
            }

        }

    }
}