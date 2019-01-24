using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_SortTriangles_v2.BL
{
    class ReversSorter : IReversSorter
    {
        public List<Triangle> ReversSort(List<Triangle> triangles)
        {
            if (triangles == null)
            {
                throw new ArgumentNullException("triangles");
            }

            triangles.Sort();
            triangles.Reverse();
            return triangles;
        }
    }
}
