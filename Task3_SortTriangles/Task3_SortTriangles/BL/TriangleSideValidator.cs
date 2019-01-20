using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_SortTriangles.BL
{
    static class TriangleSideValidator
    {
        public static bool Validate(double side1, double side2, double side3)
        {
            bool result = true;
            if (side1 <= 0 || side2 <= 0 || side3 <= 0)
            {
                return false;
            }

            if ((side1 - side2 - side3) >= 0)
            {
                result = false;
            }
            if ((side2 - side3 - side1) >= 0)
            {
                result = false;
            }
            if ((side3 - side1 - side2) >= 0)
            {
                result = false;
            }

            return result; 
        }
    }
}
