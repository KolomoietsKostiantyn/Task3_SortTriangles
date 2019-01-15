using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_SortTriangles.BL
{
    class Triangl: IComparable
    {
        public Triangl(string name, double side1, double side2, double side3)
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
                double p1 = Math.Sqrt(p*(p - Side1)*(p - Side2)*(p - Side3));
                return p1;
            }
        
        }

        public int CompareTo(object obj)
        {
            Triangl tr = obj as Triangl;

            if (tr == null)
            {
                throw new Exception("Wrond tipe");//??????????
            }

            int result = 0;
            if (Square < tr.Square)
            {
                result = -1;
            }

            if (Square > tr.Square)
            {
                result = 1;
            }

            if (Square == tr.Square)
            {
                result = 0;
            }

            return result;
        }
    }
}
