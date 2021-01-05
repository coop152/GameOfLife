using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //GameOfLife GOL = new GameOfLife(10);
            ToroidalGameOfLife GOL = new ToroidalGameOfLife(10);
            //  *
            //* *
            // **
            GOL.Field[0, 2] = true;
            GOL.Field[1, 0] = true;
            GOL.Field[1, 2] = true;
            GOL.Field[2, 1] = true;
            GOL.Field[2, 2] = true;
            //GOL.RandomiseField(25);
            Console.WriteLine(GOL.Visualise());
            while (Console.ReadLine() != "q")
            {
                GOL.GotoNextGen();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(GOL.Visualise());
            }
        }
        
    }
    class GameOfLife
    {
        static Random random = new Random();
        public bool[,] Field;
        int MaxFieldSize;
        public GameOfLife(int maxFieldSize)
        {
            MaxFieldSize = maxFieldSize;
            Field = new bool[maxFieldSize, maxFieldSize];
        }
        public void RandomiseField(int aliveChancePercent = 10)
        {
            for (int i = 0; i < MaxFieldSize; i++)
                for (int j = 0; j < MaxFieldSize; j++)
                    Field[i, j] = random.Next(100) < aliveChancePercent;
        }
        public string Visualise()
        {
            string output = "";
            for (int i = 0; i < MaxFieldSize; i++)
            {
                for (int j = 0; j < MaxFieldSize; j++)
                {
                    output += Field[i, j] ? "O" : "_";
                }
                output += "\n";
            }
            return output;
        }
        public string VisualiseWithCount()
        {
            string output = "";
            for (int i = 0; i < MaxFieldSize; i++)
            {
                for (int j = 0; j < MaxFieldSize; j++)
                {
                    output += Field[i, j] ? "O" : " ";
                    output += CountNeighbours(i, j);
                }
                output += "\n";
            }
            return output;
        }
        private int CountNeighbours(int x, int y)
        {
            int count = 0;
            for (int i = x - 1; i <= x + 1; i++)
                if (i > -1 && i < MaxFieldSize)
                {
                    for (int j = y - 1; j <= y + 1; j++)
                        if (j > -1 && j < MaxFieldSize)
                        {
                            if (!(i == x && j == y) && Field[i, j]) count++;
                        }
                }
            return count;
        }
        public void GotoNextGen()
        {
            bool[,] newField = new bool[MaxFieldSize, MaxFieldSize];
            Array.Copy(Field, newField, MaxFieldSize * MaxFieldSize); //most straight-forward way to copy an array for some god-forsaken reason
            for (int i = 0; i < MaxFieldSize; i++)
            {
                for (int j = 0; j < MaxFieldSize; j++)
                {
                    int neighbours = CountNeighbours(i, j);
                    if (Field[i, j])
                    {
                        if (neighbours < 2 || neighbours > 3)
                        {
                            newField[i, j] = false;
                        }
                    }
                    else
                    {
                        if (neighbours == 3)
                        {
                            newField[i, j] = true;
                        }
                    }
                }
            }
            Field = newField;
        }
    }

}
