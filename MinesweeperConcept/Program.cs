using System;
using System.Collections.Generic;

namespace MinesweeperConcept
{
    class Program
    {
        string[,] board;
        List<int[]> dir = new List<int[]>();
        public Program()
        {
            makeBoard(10, 20, 60);
            setDictionary();
        }
        static void Main(string[] args)
        {
            Program a = new Program();
            a.placeNumbers(a.board);
            a.showBoard(a.board);
        }

        private void showBoard(string[,] gb)
        {
            int len = gb.GetLength(0);
            int wid = gb.GetLength(1);
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < wid; j++)
                {
                    Console.Write(gb[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        private int checkMines(string[,] gb, int row, int col)
        {
            int len = gb.GetLength(0);
            int wid = gb.GetLength(1);
            int count = 0;
            foreach (int[] d in dir)
            {
                int r = row + d[0];
                int c = col + d[1];
                if (r >= 0 && r < len &&
                    c >= 0 && c < wid)
                {
                    if (gb[row + d[0], col + d[1]] == "X")
                        count++;
                }
            }
            return count;
        }
        private void placeNumbers(string[,] gb)
        {
            int len = gb.GetLength(0);
            int wid = gb.GetLength(1);

            // loop through board and check each 0
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < wid; j++)
                {
                    if (gb[i, j] == "0")
                    {
                        gb[i, j] = checkMines(gb, i, j).ToString();
                    }
                }
            }
        }
        private void makeBoard(int len, int wid, int mines)
        {
            board = new string[len, wid];
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < wid; j++)
                {
                    board[i, j] = "0";
                }
            }
            randomizeBoard(board, mines);
        }
        private void setDictionary()
        {
            dir.Add(new int[] { 0, 1 }); // right
            dir.Add(new int[] { 0, -1 }); // left
            dir.Add(new int[] { -1, 0 }); // up
            dir.Add(new int[] { 1, 0 }); // down
            dir.Add(new int[] { -1, 1 }); // rU
            dir.Add(new int[] { -1, -1 }); // rL
            dir.Add(new int[] { 1, -1 }); // dL
            dir.Add(new int[] { 1, 1 }); // dR
        }
        private string[,] randomizeBoard(string[,] gb, int mines)
        {
            int row, col;
            Random r = new Random();
            while (mines >= 0)
            {
                row = r.Next(0, gb.GetLength(0));
                col = r.Next(0, gb.GetLength(1));
                while(gb[row, col] == "X")
                {
                    row = r.Next(0, gb.GetLength(0));
                    col = r.Next(0, gb.GetLength(1));
                } 
                gb[row, col] = "X";
                mines--;
            }
            return gb;
        }
    }
}
