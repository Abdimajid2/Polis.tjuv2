using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polis.tjuv2
{
    public class Person
    {
        //Movement
        public int Movement { get; set; }

        public int Ydirection { get; set; }

        public int Xdirection { get; set; }
        //Inventory
        public List<Item> Inventory { get; set; }

        public Person()
        {
            Random random = new Random();
            Movement = random.Next(0,6);
            Inventory = new List<Item>();
            
        }

       public   void Move( )
        {
            switch(Movement)
            {
                case 0:
                    break;


            }

        }

         

        public virtual  void Removefrominventory(Item item)
        {
            Inventory.Remove(item);
        }
    }

   
    

    
}
