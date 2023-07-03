using System;
namespace Project
{
    class Sudoku
    {
        private int[,] board;
        public int[,] Board
        {
            get { return board; }
            set { board = value; }
        }

        public Sudoku(int[,] Board)
        {
            board = Board;
        }

        public bool Solve()
        {
            return Solve(0, 0);
        }

        private bool Solve(int Radif, int Satr)
        {
            if (Radif == 9)
            {
                Radif = 0;
                if (++Satr == 9)
                {
                    return true;
                }
            }

            if (board[Radif, Satr] != 0)
            {
                return Solve(Radif + 1, Satr);
            }

            for (int num = 1; num <= 9; num++)
            {
                if (IsValid(Radif, Satr, num))
                {
                    board[Radif, Satr] = num;
                    if (Solve(Radif + 1, Satr))
                    {
                        return true;
                    }
                }
            }

            board[Radif, Satr] = 0;
            return false;
        }

        private bool IsValid(int Radif, int Satr, int num)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[Radif, i] == num || board[i, Satr] == num)
                {
                    return false;
                }
            }

            int boxRadif = Radif - Radif % 3;
            int boxSatr = Satr - Satr % 3;
            for (int i = boxRadif; i < boxRadif + 3; i++)
            {
                for (int j = boxSatr; j < boxSatr + 3; j++)
                {
                    if (board[i, j] == num)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void Print()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        public static void Main()
        {
            int[,] board = new int[9, 9] {
            { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
            { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
            { 0, 9, 8, 0, 0, 0, 6, 0, 0 },
            { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
            { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
            { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
            { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
            { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
            { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
        };

            Sudoku sudoku = new Sudoku(board);
            if (sudoku.Solve())
            {
                sudoku.Print();
            }
            else
            {
                Console.WriteLine("No solution found.");
            }
        }
    }
}