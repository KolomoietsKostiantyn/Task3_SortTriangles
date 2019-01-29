using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_SortTriangles_v2.BL
{
    public class Triangle: IComparable<Triangle>
    {
        public Triangle(string name, double side1, double side2, double side3)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
            Name = name;
        }

        public string Name
        {
            get;
            private set;
        }

        public double Side1
        {
            get;
            private set;
        }

        public double Side2
        {
            get;
            private set;
        }

        public double Side3
        {
            get;
            private set;
        }

        public double Square
        {
            get
            {
                double p = (Side1 + Side2 + Side3) / 2;
                return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
            }
        }

        public int CompareTo(Triangle other)
        {
            int result = 0;
            if (Square < other.Square)
            {
                result = -1;
            }

            if (Square > other.Square)
            {
                result = 1;
            }

            return result;
        }
    }
}
