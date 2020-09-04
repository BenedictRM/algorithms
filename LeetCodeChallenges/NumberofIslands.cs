
// Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. 
// An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
// You may assume all four edges of the grid are all surrounded by water.

// char[][] grid = new char[][]{
//     new char[]{'1','1','1','1','0'},
//     new char[]{'1','1','0','1','0'},
//     new char[]{'1','1','0','0','0'},
//     new char[]{'0','0','0','0','0'}
// };//1

// // char[][] grid = new char[][]{
// //     new char[]{'1','1','0','0','0'},
// //     new char[]{'1','1','0','0','0'},
// //     new char[]{'0','0','1','0','0'},
// //     new char[]{'0','0','0','1','1'}
// // };//3
using System;
using System.Collections.Generic;

namespace algorithms
{
    //Idea:
    //maintain set of visited locations, only visit once
    //push 1's onto stack, record as visited, if stack populated pop and search, else search unvisited grid -- only push unvisited 1's
    //stop when all of grid visited 
    public class NumberofIslands
    {
        public static int NumIslands(char[][] grid) {
            HashSet<Tuple<int,int>> visited = new HashSet<Tuple<int,int>>();
            Stack<Tuple<int,int>> island = new Stack<Tuple<int,int>>();
            int islands = 0;

            for(int i = 0; i < grid.Length; i++) {
                for(int j = 0; j < grid[i].Length; j++) {
                    Tuple<int,int> visit = new Tuple<int,int>(i,j);
                    if(!visited.Contains(visit)) {
                        visited.Add(visit);

                        if(grid[i][j] == '1') {
                            island.Push(new Tuple<int,int>(i,j));
                        }

                        //if stack size > 0, explore, increment islands
                        if(island.Count > 0) {
                            explore(visited, island, grid);
                            islands++;
                        }
                    }
                }
            }

            return islands;
        }

        private static void explore(HashSet<Tuple<int,int>> visited, Stack<Tuple<int,int>> island, char[][] grid) {
            while(island.Count > 0) {
                Tuple<int, int> land = island.Pop();

                //look up
                if(land.Item1 - 1 >= 0 && grid[land.Item1 - 1][land.Item2] == '1' && !visited.Contains(new Tuple<int,int>(land.Item1 - 1, land.Item2))) {
                    visited.Add(new Tuple<int,int>(land.Item1 - 1, land.Item2));
                    island.Push(new Tuple<int,int>(land.Item1 - 1, land.Item2));
                }

                //look down
                if(land.Item1 + 1 < grid.Length && grid[land.Item1 + 1][land.Item2] == '1' && !visited.Contains(new Tuple<int,int>(land.Item1 + 1, land.Item2))) {
                    visited.Add(new Tuple<int,int>(land.Item1 + 1, land.Item2));
                    island.Push(new Tuple<int,int>(land.Item1 + 1, land.Item2));
                }

                //look left
                if(land.Item2 - 1 >= 0 && grid[land.Item1][land.Item2 - 1] == '1' && !visited.Contains(new Tuple<int,int>(land.Item1, land.Item2 - 1))) {
                    visited.Add(new Tuple<int,int>(land.Item1, land.Item2 - 1));
                    island.Push(new Tuple<int,int>(land.Item1, land.Item2 - 1));
                }

                //look right
                if(land.Item2 + 1 < grid[land.Item1].Length && grid[land.Item1][land.Item2 + 1] == '1' && !visited.Contains(new Tuple<int,int>(land.Item1, land.Item2 + 1))) {
                    visited.Add(new Tuple<int,int>(land.Item1, land.Item2 + 1));
                    island.Push(new Tuple<int,int>(land.Item1, land.Item2 + 1));
                }
            }
        }
    }
}