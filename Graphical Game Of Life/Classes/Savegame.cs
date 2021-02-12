namespace Hashing
{
    public class Savegame
    {
        public int Columns, Rows;
        public string Serialised;
        public string Name;
        public Savegame(long columns, long rows, string serialised, string name)
        {
            Columns = (int)columns;
            Rows = (int)rows;
            Serialised = serialised;
            Name = name;
        }
    }
}