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
            string[] allNames = // ger namn till personerna i staden i en random ordning
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
         
         
    }
}
