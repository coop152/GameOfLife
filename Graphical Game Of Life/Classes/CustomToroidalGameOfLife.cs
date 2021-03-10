using System;

namespace Graphical_Game_Of_Life
{
    class CustomToroidalGameOfLife : ToroidalGameOfLife
    {
        public CustomToroidalGameOfLife(bool[,] array) : base(array)
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
                        if (neighbours < UnderpopulationThreshold || neighbours > OverpopulationThreshold)
                        {
                            newField[i, j] = false;
                        }
                    }
                    else
                    {
                        if (neighbours == BirthThreshold)
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