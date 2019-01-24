using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_SortTriangles_v2.BL
{
    class FacroryBLInitializer : IFactoryBLInitializer
    {
        public IInnerDataParser CreateParser()
        {
            return new InnerDataParser();
        }

        public ITrianglStorage CreateStorage()
        {
            IReversSorter rSorter = new ReversSorter();
            ITrianglCreator tCreator = new TrianglCreator();
            ITrianglStorage result = new Storage(rSorter, tCreator);
            return result;
        }

        public IConverterTrianglToTrianglUI CreateTrianglConverter()
        {
            return new ConverterTrianglToTrianglUI();
        }
    }
}
