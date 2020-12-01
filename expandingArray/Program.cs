using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace expandingArray
{
    class Program
    {
        static void Main(string[] args)
        {
            ToroidalZone<int> zone = new ToroidalZone<int>(new int[,]{
                { 1,2,3,4,5 },
                { 10,20,30,40,50},
                { 100,200,300,400,500 },
                { 1000,2000,3000,4000,5000},
                { 10000,20000,30000,40000,50000 }
            });
            for (int j = 0; j < 5; j++)
            {
                for (int i = -10; i < 10; i++)
                {
                    Console.Write(zone[j, i]);
                    Console.Write(" ");

                }
                Console.Write("\n");
            }
            Console.ReadLine();
        }
    }
    struct ToroidalZone<T>
    {
        T[,] Zone;
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
                Zone[x % Height, y % Width] = value;
            }
        }

    }
}
