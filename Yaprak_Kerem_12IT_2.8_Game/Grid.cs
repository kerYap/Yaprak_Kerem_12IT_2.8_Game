using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Yaprak_Kerem_12IT_2_8_Game
{
    public class Grid
    {
        public int[,] grid;
        public LinkedList<(int, int)> Path { get; private set; }
        public Grid(string map)
        {
            LoadGrid(map);
            GeneratePath();
        }
        private void LoadGrid(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int rowCount = lines.Length;
            int colCount = lines[0].Split(',').Length;
            grid = new int[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                string[] values = lines[i].Split(',');
                for (int j = 0; j < colCount; j++)
                {
                    grid[i, j] = int.Parse(values[j]);
                }
            }
        }

        private void GeneratePath()
        {
            Path = new LinkedList<(int, int)>();
            (int x, int y) start = FindStartPosition();
            Path.AddLast(start);
            (int x, int y) currentPosition = start;

            while (true)
            {
                (int x, int y) nextPosition = GetNextPathPosition(currentPosition);
                if (nextPosition == (-1, -1)) break;
                Path.AddLast(nextPosition);
                currentPosition = nextPosition;
            }
        }

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
            return(0, 0);
        }

        private (int, int) GetNextPathPosition((int x, int y) currentPosition)
        {
            int x = currentPosition.x;
            int y = currentPosition.y;

            // Check all four possible directions: up, down, left, right
            if (x > 0 && (grid[x - 1, y] == 1 || grid[x - 1, y] == 2)) return (x - 1, y); // Up
            if (x < grid.GetLength(0) - 1 && (grid[x + 1, y] == 1 || grid[x + 1, y] == 2)) return (x + 1, y); // Down
            if (y > 0 && (grid[x, y - 1] == 1 || grid[x, y - 1] == 2)) return (x, y - 1); // Left
            if (y < grid.GetLength(1) - 1 && (grid[x, y + 1] == 1 || grid[x, y + 1] == 2)) return (x, y + 1); // Right

            return (-1, -1); // No more path positions
        }

        public void placeTile((int,int) index)
        {
            grid[index.Item1, index.Item2] = -2;
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

        public (int,int) startPos()
        {
            return Path.First();
        }

        public bool CanPlace((int,int) index)
        {
            if (grid[index.Item1,index.Item2] == -1) return true;
            return false;
        }
    }
}
