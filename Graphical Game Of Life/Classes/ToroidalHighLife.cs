using System;

namespace Graphical_Game_Of_Life
{
    class ToroidalHighLife : ToroidalGameOfLife
    {
        public ToroidalHighLife(bool[,] array) : base(array)
        {
        }
        public override void GotoNextGen()
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
                        if (neighbours == 3 || neighbours == 6)
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