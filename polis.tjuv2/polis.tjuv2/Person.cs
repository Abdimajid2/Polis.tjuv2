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


       

        public int TopPosition { get; set; }

        public int LeftPosition { get; set; }

        public List<Item> Inventory { get; set; }





        public Person()
        {
            Random random = new Random();
            TopDirection = random.Next(-1,2);
            LeftDirection = random.Next(-1,2);
             //Storlek på staden :)
            TopPosition = random.Next(0,26);
            LeftPosition = random.Next(0,101);
            Inventory = new List<Item>();
              
           

        }
        public virtual void ShowList()
        { 
        }

        public virtual void Meet(List<Person> city) // SKICKADE IN LISTAN I METODEN
        {
        }

        public void Move()
        {
            TopPosition = TopPosition + TopDirection ;
            LeftPosition = LeftPosition + LeftDirection ;

            // ÄNDRA TILL EN SWITCH, HÅLLER PERSONEN INNANFÖR SPELPLANEN
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
        }


        public void MoveX()
        {
            int y = 25;
            int x = 100;
            int numberOfPCharacters = 10;
            char[,] matrix = new char[y, x];
            Random random = new Random();
            for (int pcount = 0; pcount < numberOfPCharacters; pcount++)
            {
                int randomRow = random.Next(0, y);
                int randomCol = random.Next(0, x);
                matrix[randomRow, randomCol] = 'p';


            }
            while (true)


            {
                 
                 
                for (int i = 0; i < y; i++)
                {
                    for (int j = 0; j < x; j++)
                    {
                        Console.Write(matrix[i, j] == '\0' ? ' ' : matrix[i, j]);

                    }

                    Console.WriteLine();
                }
                //Fylla med 10 poliser




            }



            Console.ReadKey();
            Console.Clear();

        }

    
         

     
    }

   
    

    
}
