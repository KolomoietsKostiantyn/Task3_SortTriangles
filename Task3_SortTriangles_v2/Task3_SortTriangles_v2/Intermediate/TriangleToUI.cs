using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_SortTriangles_v2.Intermediate
{
    public class TriangleToUI
    {
        public TriangleToUI(string name, double square)
        {
            Square = square;
            Name = name;
        }

        public string Name
        {
            get;
            private set;
        }

        public double Square
        {
            get;
            private set;
        }
    }
}
