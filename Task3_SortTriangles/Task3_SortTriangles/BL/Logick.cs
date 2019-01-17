using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_SortTriangles.BL
{
    class Logick : ILogick
    {
        private List<Triangl> _triangls = new List<Triangl>();

        public bool addTriangl(string name, double side1, double side2, double side3)
        {
            bool result = false;
            Triangl nTriangl = Triangl.CreateNew(name, side1, side2, side3);
            if (nTriangl != null)
            {
                result = true;
                _triangls.Add(nTriangl);
            }
            return result;
        }

        public List<Triangl> GetReversSortedList()
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
