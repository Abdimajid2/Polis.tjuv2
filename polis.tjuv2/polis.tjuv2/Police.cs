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



    }
}