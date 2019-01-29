using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_SortTriangles_v2.BL
{
    public class Storage : ITrianglStorage
    {
        public List<Triangle> _triangls = new List<Triangle>();
        IReversSorter _reversSorter;
        ITrianglCreator _trianglCreator;

        public Storage(IReversSorter reversSorter, ITrianglCreator trianglCreator)
        {
            _trianglCreator = trianglCreator;
            _reversSorter = reversSorter;
        }

        public bool AddTriangl(string name, double side1, double side2, double side3)
        {
            bool result = false;
            Triangle nTriangl = _trianglCreator.CreateNew(name, side1, side2, side3);
            if (nTriangl != null)
            {
                result = true;
                _triangls.Add(nTriangl);
            }

            return result;
        }

        public List<Triangle> GetReversSortedList()
        {
            _triangls = _reversSorter.ReversSort(_triangls);
            List<Triangle> reverseSortedTriangl = new List<Triangle>();
            foreach (Triangle item in _triangls)
            {
                reverseSortedTriangl.Add(_trianglCreator.CreateNew(item.Name, item.Side1, item.Side2, item.Side3));
            }
            return reverseSortedTriangl;
        }
    }
}
