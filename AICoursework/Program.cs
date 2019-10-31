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


            string inputFile = System.IO.File.ReadAllText(@"C:\Users\Francesco\Desktop\AI Courserwork\caverns files\input1.cav");
            

            string[] coord = inputFile.Split(',');
            int firstNum = Convert.ToInt32(coord[0]);


            for (int i=1; i<=firstNum*2;i++) 
            {
                Cave cave= new Cave();

                cave.xCoord = Convert.ToInt32(coord[i]);
                i++;
                cave.yCoord = Convert.ToInt32(coord[i]);

                System.Console.WriteLine(cave.xCoord+", " + cave.yCoord);
            }
            
            System.Console.ReadKey();

        }
    }
}
