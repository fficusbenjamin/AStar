using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICoursework
{
    class Cave
    {
        public int xCoord, yCoord, caveNumber;
        public double gScore = double.MaxValue;
        public double fScore = double.MaxValue;
        public double hScore = double.MaxValue;
        public List<Cave> relationships = new List<Cave>();
        public Cave cameFrom;
        
    }
}
