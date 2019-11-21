using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AICoursework
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0] != null) 
            {
                List<Cave> caves = new List<Cave>();
                string inputFile = File.ReadAllText(args[0] + ".cav");
                string[] coord =inputFile.Split(',');
                int firstNum = Convert.ToInt32(coord[0]);
                int currentCave = (firstNum * 2);
                int counter = 1;
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
                }
                foreach (Cave cave1 in caves)
                {
                    addVertice(currentCave, firstNum, cave1, caves, coord, counter);
                    currentCave = currentCave + firstNum;
                }
                string path = A_Star(caves[0], caves, firstNum);
                string[] endFile = args[0].Split('.');
                string writePath = endFile[0] + ".csn";
                File.WriteAllText(writePath, path);
            }
        }

        static void addVertice(int currentCave, int firstNum, Cave cave, List<Cave> caves, string[] inputFile, int counter)
        {
            for (int i=0; i<firstNum;i++)
            {
                if (Convert.ToInt32(inputFile[currentCave + counter]) == 1) {

                    caves[i].relationships.Add(cave);
                }
                counter++;
            }
        }
        static string reconPath(Cave startCave, Cave endCave) 
        {
            List<int> solution = new List<int>();
            Cave currentCave = endCave;
            string strngSol = "";
            if (endCave.cameFrom != null)
            {
                while (currentCave != startCave)
                {
                    solution.Add(currentCave.caveNumber);
                    currentCave = currentCave.cameFrom;
                }
                solution.Add(startCave.caveNumber);
                solution.Reverse();
                foreach (int cave in solution)
                {
                    strngSol = strngSol + cave + " ";
                }
            }
            return strngSol;
        }
        
        static string A_Star(Cave startCave, List<Cave> caves, int firstNum)
        {
            List<Cave> unexpCaves = new List<Cave>();
            Cave endCave = caves[firstNum - 1];
            startCave.fScore = getDist(startCave, endCave);
            startCave.gScore = 0;
            unexpCaves.Add(startCave);
            Cave currentCave;
            string path;
            while (unexpCaves.Count > 0) 
            {
                currentCave = unexpCaves[0];
                if (currentCave == endCave) 
                {
                    path = reconPath(startCave,endCave);
                    return path;
                }
                unexpCaves.Remove(currentCave);

                foreach(Cave relationship in currentCave.relationships)
                {
                    double d = getDist(currentCave, relationship);
                    double tent_gScore = currentCave.gScore + d;
                    if (tent_gScore < relationship.gScore) 
                    {
                        relationship.cameFrom = currentCave;
                        relationship.gScore = tent_gScore;
                        relationship.fScore = relationship.gScore + relationship.hScore;
                        if (unexpCaves.Contains(relationship) == false) 
                        {
                            unexpCaves.Add(relationship);
                        }
                    }
                }
                unexpCaves.OrderBy(x=>x.fScore);
            }

            path = "0";
            return path;
        }

        public static double getDist(Cave cave1, Cave cave2) 
        {
            double distance = Math.Sqrt(Math.Pow((cave2.xCoord - cave1.xCoord), 2) + Math.Pow((cave2.yCoord - cave1.yCoord), 2));
            return distance;
        }
    }
}
