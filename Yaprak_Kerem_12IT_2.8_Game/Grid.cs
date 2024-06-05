using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Yaprak_Kerem_12IT_2._8_Game
{
    internal class Grid
    {
        LinkedList<(int, int)> enemyPath;
        public int[,] grid;
        public Grid(string map)
        {
            string line;
            string[] data;
            using(StreamReader read = new StreamReader(map))
            {
                int count = 0;
                while((line = read.ReadLine()) != null)
                {
                    data = line.Split(',');
                    for(int i = 0; i < data.Length; i++)
                    {
                        grid[count, i] = int.Parse(data[i]);
                    }
                    count++;
                }
            }
            List<(int, int)> Path = new List<(int,int)>();
            for(int i = 0; i < grid.GetLength(0); i++)
            {
                for(int j = 0; j < grid.GetLength(1); j++)
                {
                    Path.Insert(grid[i, j], (i, j));
                }
            }
            enemyPath = new LinkedList<(int, int)>(Path);
        }
        public void placeTile((int,int) index)
        {
            grid[index.Item1, index.Item2] = -2;
        }
        //public (int,int)
    }
}
