using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3_SortTriangles_v2.BL;
using Task3_SortTriangles_v2.Intermediate;

namespace Task3_SortTriangles_v2.Test.Aditional
{
    class MControlerMod : MControler
    {
        public MControlerMod(IFactoryBLInitializer BLInitializer, IVisualizer visualizator, string[] arr) 
            : base( BLInitializer,  visualizator,  arr)
        {

        }

        public void CallTryAddTriangl(string str)
        {
            TryAddTriangl(str);
        }
    }
}
