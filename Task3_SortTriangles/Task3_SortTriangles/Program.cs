using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3_SortTriangles.BL;
using Task3_SortTriangles.UInterfase;

namespace Task3_SortTriangles
{
    class Program
    {
        static void Main(string[] args) // числа с плавающей точькой вводятся через "."
        {
            UI newUI = new UI();
            newUI.InitialDate = args;
            MControler mControler = new MControler(newUI);
            newUI.Start();
        }
    }
}
