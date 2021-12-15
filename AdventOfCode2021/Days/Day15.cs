﻿using AdventOfCode2021.Constructs;
using AdventOfCode2021.Extensions;
using AdventOfCode2021.Services;

namespace AdventOfCode2021.Days
{
    public class Day15 : Day
    {

        public Day15(IFileImporter importer) : base(importer)
        {
        }

        public override int DayNumber => 15;

        protected override long ProcessPartOne(string[] input)
        {
            var grid = input.ToGrid();
            return Processday(grid);
        }

        protected override long ProcessPartTwo(string[] input)
        {
            var grid = input.ToGrid();
            var largeGrid = EnlargeGrid(grid, 5);
            return Processday(largeGrid);
        }

        private int[,] EnlargeGrid(int[,] grid, int factor)
        {
            var oldWith = grid.GetLength(0);
            var oldHeight = grid.GetLength(1);
            var width = oldWith * factor;
            var heigth = oldHeight * factor;

            var largeGrid = new int[width, heigth];

            for (int y = 0; y < factor; y++)
            {
                for (int x = 0; x < factor; x++)
                {
                    for (int j = 0; j < grid.GetLength(1); j++)
                    {
                        for (int i = 0; i < grid.GetLength(0); i++)
                        {
                            var value = grid[i, j] + y + x;
                            if (value > 9)
                            {
                                value -= 9;
                            }
                            largeGrid[i + (oldWith * x), j + (oldHeight * y)] = value;
                        }
                    }

                }
            }

            return largeGrid;
        }

        private long Processday(int[,] grid)
        {
            var nodeGrid = new Day15Node[grid.GetLength(0), grid.GetLength(1)];
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    var newNode = new Day15Node { X = i, Y = j, Value = grid[i, j] };
                    nodeGrid[i, j] = newNode;
                }
            }

            for (int j = 0; j < grid.GetLength(1); j++)
            {
                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    var current = nodeGrid[i, j];
                    foreach (var p in grid.Adjacent(i, j))
                    {
                        current.Connections.Add(nodeGrid[p.X, p.Y]);
                    }
                }
            }

            Day15Node wanted = nodeGrid[grid.GetLength(0) - 1, grid.GetLength(1) - 1];
            Day15Node start = nodeGrid[0, 0];
            start.Distance = 0;
            start.Value = 0;
            var nodes = new PriorityQueue<Day15Node, int>();

            nodes.Enqueue(start, start.Value);
            ProcessNodes(nodes, wanted);

            return wanted.Distance;
        }

        private void ProcessNodes(PriorityQueue<Day15Node, int> nodes, Day15Node wanted)
        {
            while (nodes.TryDequeue(out Day15Node node, out _))
            {
                if (node.Visited)
                {
                    continue;
                }

                if (node == wanted)
                {
                    break;
                }

                node.Visited = true;
                foreach (var connection in node.Connections.Where(c => !c.Visited))
                {
                    var value = node.Distance + connection.Value;
                    if (value < connection.Distance)
                    {
                        connection.Distance = value;
                    }

                    nodes.Enqueue(connection, connection.Distance);
                }
            }
        }
    }
}
