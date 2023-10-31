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

        public int PoorTopPosition { get; set; }

        public int PoorLeftPosition { get; set; }


        public List<Item> Inventory { get; set; }
 
        public Person()
        {
            Random random = new Random();
            TopDirection = random.Next(-1,2);
            LeftDirection = random.Next(-1,2);
             //Storlek på staden :)
            TopPosition = random.Next(1,25);
            LeftPosition = random.Next(1,100);
            Inventory = new List<Item>(); // en gemensam lista för alla personer i staden
            PrisonerTopPosition = random.Next(31, 40);  //inuti fängelset
            PrisonerLeftPosition = random.Next(1, 10);
            PoorTopPosition = random.Next(42, 51);  //inuti poorhouse
            PoorLeftPosition = random.Next(1, 50);




        }
        public virtual void ShowList()
        { 
        }

        public virtual CityPrison Meet(List<Person> city, List<Person> prison,List<Person>poorhouse) // SKICKADE IN LISTAN I METODEN
        {

            CityPrison cityPrison = new CityPrison();
            cityPrison.Prison = prison;
            cityPrison.City = city;
            cityPrison.Poorhouse = poorhouse;
            return cityPrison;
        }
     

        public virtual void Move()
        {
            TopPosition = TopPosition + TopDirection ;
            LeftPosition = LeftPosition + LeftDirection ;
            PrisonerTopPosition = PrisonerTopPosition + TopDirection;
            PrisonerLeftPosition = PrisonerLeftPosition + LeftDirection;
            PoorTopPosition = PoorTopPosition + TopDirection ;
            PoorLeftPosition= PoorLeftPosition + LeftDirection ;
            // HÅLLER PERSONEN INNANFÖR SPELPLANEN
            if (TopPosition < 1)
            {
                TopPosition = 23;
            }
            else if (TopPosition > 23)
            {
                TopPosition = 1;
            }
            if (LeftPosition < 1)
            {
                LeftPosition = 98;
            }
            else if (LeftPosition > 98)
            {
                LeftPosition = 1;
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
            if (PoorTopPosition < 42)
            {
                PoorTopPosition = 49;
            }
            else if (PoorTopPosition > 49)
            {
                PoorTopPosition =42 ;
            }
            if (PoorLeftPosition < 1)
            {
                PoorLeftPosition = 48;
            }
            else if (PoorLeftPosition > 48)
            {
                PoorLeftPosition = 1;
            }

        }



     
    }

   
    

    
}
