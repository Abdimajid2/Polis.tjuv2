﻿using System;
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

        




        public Person( )
        {
            Random random = new Random();
            TopDirection = random.Next(-1,2);
            LeftDirection = random.Next(-1,2);
        
            TopPosition = random.Next(0,26);
            LeftPosition = random.Next(0,101);
            Inventory = new List<Item>();
              
            
        }
      
       public void Move()
        {
            TopPosition = TopPosition + TopDirection ;
            LeftPosition = LeftPosition + LeftDirection ;
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
                //Direction = random.Next(0, 6);
                //switch (Direction)
                //{
                //    case 0:
                //        x -= 1;
                //        break;
                //    case 1:
                //        y += 1;
                //        break;
                //    case 2:
                //        x += 1;
                //        break;
                //    case 3:
                //        y -= 1;
                //        break;
                //    case 4:
                //        x = 0;
                //        break;
                //    case 5:
                //        y = 0;
                //        break;



                //}
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
