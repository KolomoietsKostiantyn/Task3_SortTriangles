using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3_SortTriangles_v2.Intermediate;

namespace Task3_SortTriangles_v2.Test.Aditional
{
    class TriangleToUICompare: IComparer
    {
        public int Compare(object x, object y)
        {
            TriangleToUI tr1 = x as TriangleToUI;
            TriangleToUI tr2 = y as TriangleToUI;
            if (tr1 == null || tr2 == null)
            {
                throw new ArgumentException();
            }
            if (tr1.Name == tr2.Name && tr1.Square == tr2.Square)
            {
                return 0;
            }

            return -1;
        }
    }
}
