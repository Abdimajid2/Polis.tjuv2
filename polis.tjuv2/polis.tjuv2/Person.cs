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
        
        //Inventory
        public List<Item> Inventory { get; set; }

        public Person()
        {
            Random random = new Random();
            Movement = random.Next(0,6);
            
        }

       public void Move()
        {
            switch(Movement)
            {
                case 0:
                    break;


            }

        }

    }

   
    

    
}
