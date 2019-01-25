using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3_SortTriangles_v2.BL;

namespace Task3_SortTriangles_v2.Test.Aditional
{
    class TriangleCompare : IComparer
    {
        public int Compare(object x, object y)
        {
            Triangle tr1 = x as Triangle; 
            Triangle tr2 = y as Triangle;
            if (tr1 == null || tr2 == null)
            {
                throw new ArgumentException();
            }
            if (tr1.Name == tr2.Name && tr1.Side1 == tr2.Side1 &&
                    tr1.Side2 == tr2.Side2 && tr1.Side3 == tr2.Side3)
            {
                return 0;
            }

            return -1;
        }
    }
}
