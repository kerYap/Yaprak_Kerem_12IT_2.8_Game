using System;
using System.Collections.Generic;
using System.IO;

namespace Yaprak_Kerem_12IT_TD_Game
{
    public class Grid
    {
        //variables
        public int[,] grid;
        public LinkedList<(int, int)> Path { get; private set; }
        private bool[,] visited;
        //
        public LevelBase thisLevel; 

        private uint returnMoney;

        /// <summary>
        /// constructor makes the map and path
        /// </summary>
        /// <param name="map">the filepath of the map</param>
        public Grid(string map, LevelBase thisLevel)
        {
            LoadGrid(map);
            GeneratePath();
            this.thisLevel = thisLevel;
        }

        public void ReturnMoney(uint r)
        {
            returnMoney = r;
            thisLevel.ReturnMoney(returnMoney);
        }

        /// <summary>
        /// copys the data of a .csv into the integer grid
        /// </summary>
        /// <param name="filePath">filepath of the .csv</param>
        private void LoadGrid(string filePath)
        {
            string[] files = Directory.GetFiles(filePath, "*.csv");
            string[] lines = File.ReadAllLines(files[0]);
            int rowCount = lines.Length;
            int colCount = lines[0].Split(',').Length;
            grid = new int[rowCount, colCount];
            visited = new bool[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                string[] values = lines[i].Split(',');
                for (int j = 0; j < colCount; j++)
                {
                    grid[i, j] = int.Parse(values[j]);
                    visited[i, j] = false;
                }
            }
        }

        /// <summary>
        /// Generates the enemy path in the form of a linked list
        /// </summary>
        private void GeneratePath()
        {
            Path = new LinkedList<(int, int)>();
            (int x, int y) start = FindStartPosition();
            Path.AddLast(start);
            visited[start.x, start.y] = true;
            (int x, int y) currentPosition = start;

            while (true)
            {
                (int x, int y) nextPosition = GetNextPathPosition(currentPosition);
                if (nextPosition == (-1, -1)) break;
                Path.AddLast(nextPosition);
                visited[nextPosition.x, nextPosition.y] = true;
                currentPosition = nextPosition;
            }
        }

        /// <summary>
        /// finds the start position (the 0) in the integer array
        /// </summary>
        /// <returns>the index of the start position in the grid</returns>
        private (int, int) FindStartPosition()
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == 0)
                    {
                        return (i, j);
                    }
                }
            }
            throw new Exception("start pos not found");
        }

        private (int, int) GetNextPathPosition((int x, int y) currentPosition)
        {
            int x = currentPosition.x;
            int y = currentPosition.y;

            // Check all four possible directions: up, down, left, right
            if (x > 0 && (grid[x - 1, y] == 1 || grid[x - 1, y] == 2) && !visited[x - 1, y]) return (x - 1, y); // Left
            if (x < grid.GetLength(0) - 1 && (grid[x + 1, y] == 1 || grid[x + 1, y] == 2) && !visited[x + 1, y]) return (x + 1, y); // Right
            if (y > 0 && (grid[x, y - 1] == 1 || grid[x, y - 1] == 2) && !visited[x, y - 1]) return (x, y - 1); // Down
            if (y < grid.GetLength(1) - 1 && (grid[x, y + 1] == 1 || grid[x, y + 1] == 2) && !visited[x, y + 1]) return (x, y + 1); // Up

            return (-1, -1); // No more path positions
        }

        public void placeTile((int,int) index)
        {
            grid[index.Item2, index.Item1] = -2;
        }

        public (int, int)? nextTile((int,int) currentPosition)
        {
            var node = Path.First;
            while (node != null)
            {
                if (node.Value == currentPosition)
                {
                    return node.Next?.Value;
                }
                node = node.Next;
            }
            return null; // Return null if the current position is not in the path or is the last position
        }

        public bool CanPlace((int,int) index)
        {
            if (index.Item2 > grid.GetLength(0) - 1 || index.Item1 > grid.GetLength(1) - 1 || index.Item2 <0||index.Item1 <0) return false;
            if (grid[index.Item2, index.Item1] == -1) return true;
            return false;
        }
        public void deleteTile((int,int) index)
        {
            grid[index.Item2, index.Item1] = -1;
        }
    }
}