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

        public bool Prison { get; set; }

        public List<Item> StolenGoods { get; set; }

        public char Name { get; set; }

        public Thief()
        {
            Name = 'T';

            List<Item> stolenGoods = new List<Item>();

            StolenGoods = stolenGoods;



        }

        public override void ShowList()
        {
            foreach (Item item in StolenGoods)
            {
                Console.Write(item.ItemName + " ");
            }
        }


        public override void Meet()
        {
            if 
            { 

            }

        }


    }


}
