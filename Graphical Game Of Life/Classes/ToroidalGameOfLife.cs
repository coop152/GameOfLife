﻿using System;

namespace Graphical_Game_Of_Life
{
    class ToroidalGameOfLife
    {
        public int Columns { get => Field.Columns; }
        public int Rows { get => Field.Rows; }
        public int UnderpopulationThreshold = 2;
        public int OverpopulationThreshold = 3;
        public int BirthThreshold = 3;
        static readonly Random random = new Random();
        public static ToroidalGameOfLife Deserialise(string serialised, int rows, int columns)
        {
            ToroidalGameOfLife result = new ToroidalGameOfLife(rows, columns);
            for (int i = 0; i < serialised.Length; i++)
            {
                result.SetCell(i / columns, i % columns, serialised[i] == 'x');
            }
            return result;
        }
        protected ToroidalField<bool> Field;
        public ToroidalGameOfLife(int rows, int columns)
        {
            Field = new ToroidalField<bool>(rows, columns);
        }
        public ToroidalGameOfLife(bool[,] array)
        {
            Field = new ToroidalField<bool>(array.GetLength(0), array.GetLength(1));
            Field.Zone = array;
        }
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
        protected virtual int CountNeighbours(int x, int y)
        {
            int count = 0;
            for (int i = x - 1; i <= x + 1; i++)
                for (int j = y - 1; j <= y + 1; j++)
                    if (!(i == x && j == y) && Field[i, j]) count++;
            return count;
        }
        public virtual void GotoNextGen()
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
        public bool[,] AsArray() => Field.Zone;
        public void ResizeField(int rows, int columns) => Field.ResizeZone(rows, columns);
        public void SetCell(int x, int y, bool value) => Field[x, y] = value;
        public bool GetCell(int x, int y) => Field[x, y];
        public void FlipCell(int x, int y) => Field[x, y] = !Field[x, y];

    }

}
