using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3_SortTriangles.BL;
using Task3_SortTriangles.UI;

namespace Task3_SortTriangles
{
    class Program
    {
        static void Main(string[] args) 
        {
            ConsoleUI newUI = new ConsoleUI();
            MControler mControler = new MControler(newUI, args);
            mControler.Start();
        }
    }
}
