using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_SortTriangles_v2.BL
{
    public class FacroryBLInitializer: IFactoryBLInitializer
    {
        public ITrianglStorage CreateStorage()
        {
            IReversSorter reversSorter = new ReversSorter();
            ITrianglCreator trianglCreator = new TrianglCreator();
            return new Storage(reversSorter, trianglCreator);
        }

        public IConverterTrianglToTrianglUI CreateConverterTrianglToTrianglUI()
        {
            return new ConverterTrianglToTrianglUI(); 
        }

        public IInnerDataParser CreateInnerDataParser()
        {
            return new InnerDataParser();
        }

    }
}
