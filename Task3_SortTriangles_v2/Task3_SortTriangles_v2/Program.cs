using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3_SortTriangles_v2.BL;
using Task3_SortTriangles_v2.Intermediate;
using Task3_SortTriangles_v2.UI;

namespace Task3_SortTriangles_v2
{
    class Program
    {
        static void Main(string[] args)
        {

            IFactoryBLInitializer factoryBLInitializer = new FacroryBLInitializer();

            IVisualizer visualizer = new ConsoleUI();
            MControler mControler = new MControler(visualizer, factoryBLInitializer, args);
            mControler.Start();
        }
    }
}
