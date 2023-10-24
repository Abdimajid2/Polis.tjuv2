﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace polis.tjuv2
{
    public class Citizen : Person
    {

        public List<Item>Belongings  { get; set; }

        public Citizen()
        {


            Character = 'C'; // en bokstav som representerar medborgaren i staden

          List<Item> belongings= new List<Item>();  // här förvaras medborgarens saker i en lista.
         
            


              
               belongings.Add(new Item("nycklar")); // saker som medborgaren har med sig
                belongings.Add(new Item("plånbok"));
               belongings.Add(new Item("mobil"));
               belongings.Add(new Item("klocka"));
               
               



            Belongings = belongings; 
            
        }

        public override void ShowList()
        {
            foreach(Item item in Belongings)
            {
                Console.Write(item.ItemName + " ");
            }
           


        }

    }
}
