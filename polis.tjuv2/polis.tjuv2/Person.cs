using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polis.tjuv2
{
    public class Person
    {
        
        public int TopDirection { get; set; }

        public int LeftDirection { get; set; }

        public char Character { get; set; }
        public string Name { get; set; }

        public int TopPosition { get; set; }

        public int LeftPosition { get; set; }

        public int PrisonerTopPosition{ get; set; }

        public int PrisonerLeftPosition { get; set; }

        public List<Item> Inventory { get; set; }
 
        public Person()
        {
            Random random = new Random();
            TopDirection = random.Next(-1,2);
            LeftDirection = random.Next(-1,2);
             //Storlek på staden :)
            TopPosition = random.Next(0,26);
            LeftPosition = random.Next(0,101);
            Inventory = new List<Item>(); // en gemensam lista för alla personer i staden
            PrisonerTopPosition = random.Next(31, 40);
            PrisonerLeftPosition = random.Next(1, 10);



        }
        public virtual void ShowList()
        { 
        }

        public virtual CityPrison Meet(List<Person> city, List<Person> prison) // SKICKADE IN LISTAN I METODEN
        {

            CityPrison cityPrison = new CityPrison();
            cityPrison.Prison = prison;
            cityPrison.City = city;
            return cityPrison;
        }
     

        public virtual void Move()
        {
            TopPosition = TopPosition + TopDirection ;
            LeftPosition = LeftPosition + LeftDirection ;
            PrisonerTopPosition = PrisonerTopPosition + TopDirection;
            PrisonerLeftPosition = PrisonerLeftPosition + LeftDirection;
            // HÅLLER PERSONEN INNANFÖR SPELPLANEN
            if (TopPosition < 0)
            {
                TopPosition = 25;
            }
            else if (TopPosition > 25)
            {
                TopPosition = 0;
            }
            if (LeftPosition < 0)
            {
                LeftPosition = 100;
            }
            else if (LeftPosition > 100)
            {
                LeftPosition = 0;
            }
            if (PrisonerTopPosition < 31)
            {
                PrisonerTopPosition = 38;
            }
            else if(PrisonerTopPosition >38) 
            { 
                PrisonerTopPosition = 31;
            }
            if (PrisonerLeftPosition < 1)
            {
                PrisonerLeftPosition = 8;
            }
            else if (PrisonerLeftPosition > 8)
            {
                PrisonerLeftPosition = 1;
            }
        }



     
    }

   
    

    
}
