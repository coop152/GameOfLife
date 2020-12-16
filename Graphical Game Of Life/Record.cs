using System.Linq;
using System.Text;

namespace Hashing
{
    public struct Record
    {
        public string Username;
        public byte[] Hashed;
        public byte[] Salt;
        public string HashString => string.Join(" ", Hashed.Select(x => x.ToString("x2")));
    }
}