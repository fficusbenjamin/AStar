using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICoursework
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Cave> caves = new List<Cave>();


            //string inputFile = System.IO.File.ReadAllText(@"C:\Users\Francesco\Desktop\AI Courserwork\caverns files\input1.cav");
            //string inputFile = System.IO.File.ReadAllText(@"/Users/francesco/Desktop/caverns files/input1.cav");
            string inputFile = "7,2,8,3,2,14,5,7,6,11,2,11,6,14,1,0,0,0,1,0,0,0,0,0,0,1,1,0,0,0,0,0,0,1,1,1,1,0,0,0,1,1,0,0,1,1,1,0,0,0,0,0,1,1,0,0,0,0,0,1,0,0,0,0";


            string[] coord =inputFile.Split(',');
            int firstNum = Convert.ToInt32(coord[0]);
            int currentCave = (firstNum * 2);

            int num = 1;
            for (int i=1; i<=firstNum*2;i++) 
            {
                Cave cave= new Cave();
                cave.caveNumber = num;
                cave.xCoord = Convert.ToInt32(coord[i]);
                i++;
                num++;
                cave.yCoord = Convert.ToInt32(coord[i]);
                caves.Add(cave);

                System.Console.WriteLine(cave.caveNumber + " - " + cave.xCoord+", " + cave.yCoord);

                

                
            }

            foreach (Cave cave1 in caves)
            {

                currentCave = currentCave + firstNum;
                addVertice(currentCave, firstNum, cave1, caves, coord);
                System.Console.WriteLine(currentCave);

            }


            System.Console.ReadLine();

        }



        static void addVertice(int currentCave, int firstNum, Cave cave, List<Cave> caves, string[] inputFile)
        {
            for (int i=0; i<firstNum;i++)
            {
                if (Convert.ToInt16(inputFile[currentCave-1]) == 1) {

                    caves[i+1].relationships.Add(cave);
                }
            }
        }
    }
}
