using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_SortTriangles_v2.BL
{
    public class TrianglCreator: ITrianglCreator
    {
        public  Triangle CreateNew(string name, double side1, double side2, double side3)
        {
            Triangle newTriangl = null;
            if (ValidateTrianglSide(side1, side2, side3) && !string.IsNullOrWhiteSpace(name))
            {
                newTriangl = new Triangle(name, side1, side2, side3);
            }
            return newTriangl;
        }


        public bool ValidateTrianglSide(double side1, double side2, double side3)
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
