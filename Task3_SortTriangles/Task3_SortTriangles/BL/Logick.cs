using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_SortTriangles.BL
{
    class Logick : ILogick
    {
        private List<Triangle> _triangls = new List<Triangle>();

        public bool addTriangl(string name, double side1, double side2, double side3)
        {
            bool result = false;
            Triangle nTriangl = Triangle.CreateNew(name, side1, side2, side3);
            if (nTriangl != null)
            {
                result = true;
                _triangls.Add(nTriangl);
            }
            return result;
        }

        public List<Triangle> GetReversSortedList()
        {
            if (_triangls.Count == 0)
            {
                return null;
            }

            _triangls.Sort();
            _triangls.Reverse();

            return _triangls;
        }

    }
}
