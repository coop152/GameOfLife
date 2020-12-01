using System;

namespace Graphical_Game_Of_Life
{
    struct ToroidalField<T>
    {
        public T[,] Zone;
        public int Columns, Rows;
        public ToroidalField(int rows, int columns)
        {
            Zone = new T[rows, columns];
            Columns = columns;
            Rows = rows;
        }
        public ToroidalField(T[,] array)
        {
            Zone = array;
            Rows = array.GetLength(0);
            Columns = array.GetLength(1);
        }
        public void ResizeZone(int rows, int columns)
        {
            T[,] newZone = new T[rows, columns];
            int oldRows = Rows;
            int oldColumns = Columns;
            int rowLimit = Math.Min(rows, oldRows);
            int columnLimit = Math.Min(columns, oldColumns);
            for (int i = 0; i < rowLimit; i++)
            {
                for (int j = 0; j < columnLimit; j++)
                {
                    newZone[i, j] = Zone[i, j];
                }
            }
            Zone = newZone;
            Columns = columns;
            Rows = rows;
        }
        public T this[int desiredRow, int desiredColumn]
        {
            get
            {
                while (desiredRow < 0)
                {
                    desiredRow = Rows + desiredRow;
                }
                while (desiredColumn < 0)
                {
                    desiredColumn = Columns + desiredColumn;
                }
                return Zone[desiredRow % Rows, desiredColumn % Columns];
            }
            set
            {
                while (desiredRow < 0)
                {
                    desiredRow = Rows + desiredRow;
                }
                while (desiredColumn < 0)
                {
                    desiredColumn = Columns + desiredColumn;
                }
                Zone[desiredRow % Rows, desiredColumn % Columns] = value;
            }
        }
        public int GetLength(int dimension) => Zone.GetLength(dimension);

    }

}
