using System;

namespace GameOfLifeConsole
{
    struct ToroidalZone<T>
    {
        public T[,] Zone;
        int Width, Height;
        public ToroidalZone(int width, int height)
        {
            Zone = new T[height, width];
            Width = width;
            Height = height;
        }
        public ToroidalZone(T[,] array)
        {
            Zone = array;
            Height = array.GetLength(0);
            Width = array.GetLength(1);
        }
        public T this[int x, int y]
        {
            get
            {
                while (x < 0)
                {
                    x = Height + x;
                }
                while (y < 0)
                {
                    y = Width + y;
                }
                return Zone[x % Height, y % Width];
            }
            set
            {
                while (x < 0)
                {
                    x = Height + x;
                }
                while (y < 0)
                {
                    y = Width + y;
                }
                Zone[x % Height, y % Width] = value;
            }
        }

    }

    class ToroidalGameOfLife
    {
        static Random random = new Random();
        public ToroidalZone<bool> Field;
        int MaxFieldSize;
        public ToroidalGameOfLife(int maxFieldSize)
        {
            MaxFieldSize = maxFieldSize;
            Field = new ToroidalZone<bool>(maxFieldSize, maxFieldSize);
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
                for (int j = y - 1; j <= y + 1; j++)
                    if (!(i == x && j == y) && Field[i, j]) count++;
            return count;
        }
        public void GotoNextGen()
        {
            ToroidalZone<bool> newField = new ToroidalZone<bool>(MaxFieldSize, MaxFieldSize);
            Array.Copy(Field.Zone, newField.Zone, MaxFieldSize * MaxFieldSize);
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
