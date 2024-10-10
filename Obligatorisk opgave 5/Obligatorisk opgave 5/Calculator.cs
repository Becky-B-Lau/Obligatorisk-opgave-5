using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_opgave_5
{
    public class Calculator
    {
        public int Add(int X, int Y)
        {
            return X + Y;
        }
        public int Subtract(int X, int Y)
        {
            return X - Y;
        }

        public int Random(int X, int Y)
        {
            Random random = new Random();
            return random.Next(X, Y);
        }

    }
}
