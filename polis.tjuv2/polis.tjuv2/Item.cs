using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polis.tjuv2
{
    public class Item : Person
    {
        public string Name { get; set; }

        public Item(string name)
        {

            Name = name;

        }
    }
}
