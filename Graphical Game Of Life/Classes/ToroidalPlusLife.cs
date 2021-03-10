namespace Graphical_Game_Of_Life
{
    class ToroidalPlusLife : ToroidalGameOfLife
    {
        public ToroidalPlusLife(bool[,] array) : base(array)
        {
        }
        protected override int CountNeighbours(int x, int y)
        {
            (int, int)[] relativeChecks = { (0, -1), (0, 1), (-1, 0), (1, 0), (0, -2), (0, 2), (-2, 0), (2, 0) }; //count 8 tiles in plus area around cell
            int count = 0;
            foreach (var (checkX, checkY) in relativeChecks)
            {
                if (Field[x + checkX, y + checkY]) count++;
            }
            return count;
        }
    }
}