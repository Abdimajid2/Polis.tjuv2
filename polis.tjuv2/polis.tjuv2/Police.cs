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
        public List<Status> Policesatus { get; set; }

        public Police()
        {
            List<Item> confiscated = new List<Item>(); // skapar en lista för polisen där sakerna som har tagits från tjuven förvaras
                                                      
            Confiscated = confiscated;

            Character = 'P'; //en bokstav som representerar polis i staden

            List<Status> policestatus = new List<Status>();
            Policesatus = policestatus;
              
        }

        public override void ShowList()   
        {
            foreach (Item item in Confiscated)
            {
                Console.Write(item.ItemName + " ");
            }
  
        }

        public override int Meet(List<Person> city, int numbersOfRobberies) // skickade in listan med personer i metoden
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
                            Confiscated.AddRange(thief.StolenGoods); // polisen kopierar hela tjuvens lista
                            Console.SetCursorPosition(0, 27);
                            Console.Write("Polisen har fångat en tjuv som hade tagit ");
                            ShowList();
                            
                            Console.WriteLine();
                            thief.StolenGoods.Clear(); // polisen tömmer hela tjuvens lista
                            int x = 0;
                            //Console.WriteLine("polisen träffar tjuven och tar hans grejer");
                        }
                    }
                    else if (person is Citizen) // vad som händer när en polis möter medborgare
                    {
                      

                    }
                    else if (person is Police) // vad som händer när polis möter en annan polis
                    {
                      

                    }

                    
                }
               
            }
            return numbersOfRobberies;

        }

    }
}