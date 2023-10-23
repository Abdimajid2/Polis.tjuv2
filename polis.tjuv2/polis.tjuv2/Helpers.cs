using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polis.tjuv2
{
    internal class Helpers
    {
        public static string GetRandomName()
        {
            string[] allNames =
            {
             "Andersson",
             "Johansson",
             "Karlsson",
             "Nilsson",
             "Eriksson",
             "Larsson",
             "Olsson",
             "Persson",
             "Svensson",
             "Gustafsson",
             "Pettersson",
             "Berg",
             "Håkansson",
             "Bergström",
             "Lundberg",
             "Lindgren",
             "Månsson",
             "Holm",
             "Sandberg",
             "Ahlström",
             "Göransson",
             "Söderström",
             "Löfgren",
             "Ekström",
             "Malm",
             "Östberg",
             "Nyström",
             "Westman",
             "Hedlund",
             "Krantz",


            };
            Random random = new Random();
            int rnd = random.Next(allNames.Length-1);
            return allNames[rnd];
        }
        //public static List <Person> FillInventory()
        //{
        //    List <Person> belongings = new List <Person>();

        //    belongings.Add

        //}


        //public static List <Medborgare> FillCity(int citizenSize)
        //{
        //    List <Medborgare> city = new List <Medborgare>();

        //    for(int i = 0; i <= citizenSize; i++)
        //    {
        //        Medborgare citizen = new Medborgare(33);

        //        city.Add(citizen);
        //    }
        //    return city;
        //}
    }
}
