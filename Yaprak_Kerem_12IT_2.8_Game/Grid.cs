﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Yaprak_Kerem_12IT_2._8_Game
{
    internal class Grid
    {
        public int[,] grid;
        LinkedList<(int, int)> enemyPath = new LinkedList<(int, int)>();
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
            
            //search for start pos
            for(int i = 0; i < grid.GetLength(0); i++)
            {
                for(int j = 0; j < grid.GetLength(1); j++)
                {

                }
            }
        }

        public void placeTile((int,int) index)
        {
            grid[index.Item1, index.Item2] = -2;
        }

        public (int, int) nextTile((int,int) currentTileIndex, (int,int) previousTileIndex)
        {
            //adjacent search for next 1
            //up down search
            //up search
            if (grid[currentTileIndex.Item1 + 1, currentTileIndex.Item2] == 1 && ((currentTileIndex.Item1 + 1) != previousTileIndex.Item1))
            {
                return (1, 1);
            }
            return (1, 1);
        }

        public (int,int) startPos()
        {
            return enemyPath.First();
        }

        public bool CanPlace((int,int) index)
        {
            if (grid[index.Item1,index.Item2] == -1) return true;
            return false;
        }
    }
}