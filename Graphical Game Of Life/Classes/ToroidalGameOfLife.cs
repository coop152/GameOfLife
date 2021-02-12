using System;

namespace Graphical_Game_Of_Life
{
    class ToroidalGameOfLife
    {
        static readonly Random random = new Random();
        ToroidalField<bool> Field;
        public ToroidalGameOfLife(int rows, int columns)
        {
            Field = new ToroidalField<bool>(rows, columns);
        }
        public bool[,] AsArray() => Field.Zone;
        public string GetSerialised()
        {
            string result = string.Empty;
            foreach (var x in Field.Zone) //shouldnt be breaking my OOP rules and using Zone directly but i dont care
            {
                result += x ? "x" : "o";
            }
            return result;
        }
        public void RandomiseField(int aliveChancePercent = 10)
        {
            for (int i = 0; i < Field.Rows; i++)
                for (int j = 0; j < Field.Columns; j++)
                    Field[i, j] = random.Next(100) < aliveChancePercent;
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
            ToroidalField<bool> newField = new ToroidalField<bool>(Field.Rows, Field.Columns);
            Array.Copy(Field.Zone, newField.Zone, Field.Rows * Field.Columns);
            for (int i = 0; i < Field.Rows; i++)
            {
                for (int j = 0; j < Field.Columns; j++)
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
        public void ResizeField(int rows, int columns) => Field.ResizeZone(rows, columns);
        public void SetCell(int x, int y, bool value) => Field[x, y] = value;
        public bool GetCell(int x, int y) => Field[x, y];
        public void FlipCell(int x, int y) => Field[x, y] = !Field[x, y];
    }

}
