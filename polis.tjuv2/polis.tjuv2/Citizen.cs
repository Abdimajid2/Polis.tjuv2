using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace polis.tjuv2
{
    public class Citizen : Person
    {

       

        public Citizen()
        {




            List<Item> belongings = new List<Item>();  // här förvaras medborgarens saker i en lista.

            Inventory.Add(new Item("nycklar"));
            belongings.Add(new Item("plånbok"));
            belongings.Add(new Item("mobil"));

           


        }


    }
}
