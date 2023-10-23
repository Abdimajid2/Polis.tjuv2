using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace polis.tjuv2
{
    public class Thief : Person
    {
        Random random = new Random();
        public bool Prison { get; set; }

        public List<Item> StolenGoods { get; set; }

        public char Name { get; set; }

        public Thief()
        {
            Name = 'T';

            List<Item> stolenGoods = new List<Item>();

            StolenGoods = stolenGoods;

            Character = 'T';


        }

        public override void ShowList()
        {
            foreach (Item item in StolenGoods)
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
                        
                    }
                    else if (person is Citizen)
                    {
                        //Console.WriteLine("det är en medborgare");
                        Citizen citizen = (Citizen)person; // MÅSTE CASTA OM PERSON TILL EN CITIZEN FÖR ATT KOMMA ÅT SUBKLASS PROP


                        if (citizen.Belongings.Count > 0) // KOLLAR OM CITIZEN HAR BELONGINGS KVAR
                        {

                            int targetitem = random.Next(0,citizen.Belongings.Count); // randomeserar villket föremål tjuven tar från medborgaren
                            this.StolenGoods.Add(citizen.Belongings[targetitem]); // KOPERIAR CITIZENS BELONGING TILL THIEF LISTA
                            citizen.Belongings.RemoveAt(targetitem); // TAR BORT BELONGING FRÅN CITIZEN
                            
                        }

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
