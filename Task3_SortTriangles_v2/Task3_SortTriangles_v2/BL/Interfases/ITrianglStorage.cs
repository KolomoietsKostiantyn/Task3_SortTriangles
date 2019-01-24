using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_SortTriangles_v2.BL
{
    public interface ITrianglStorage
    {
        bool addTriangl(string name, double side1, double side2, double side3);
        List<Triangle> GetReversSortedList();
    }
}
