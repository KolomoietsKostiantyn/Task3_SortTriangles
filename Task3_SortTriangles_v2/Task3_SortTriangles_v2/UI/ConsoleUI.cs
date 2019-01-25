using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3_SortTriangles_v2.Intermediate;

namespace Task3_SortTriangles_v2.UI
{
    class ConsoleUI: IVisualizer
    {
        private string Instruction = "Add a triangle in the format <name>, <side length>, <side length>, <side length> " +
                   "if you use floating-point numbers write them through '.'";
        private int accuracy = 3;

        public string AskForData()
        {
            Console.WriteLine("Enter the data to create a triangle in the format:  name, side length, side length, side length");
            return Console.ReadLine();
        }

        public bool ContinueRequest()
        {
            Console.WriteLine("Continue?");
            string ask = Console.ReadLine();
            ask = ask.ToLower();
            bool result = false;
            if (ask == "y" || ask == "yes")
            {
                result = true;
            }
            return result;
        }

        public void ReturnAnsver(IEnumerable<TriangleToUI> roll)
        {

            Console.WriteLine("============= Triangles list: ===============");
            int i = 1;
            foreach (TriangleToUI item in roll)
            {
                double squere = Math.Round(item.Square, accuracy);
                Console.WriteLine(string.Format("{0}. [{1}]: {2} сm", i , item.Name, squere));
                i++;
            }
            Console.ReadKey();
        }

        public void ReturnMessage(ExecutionResult result)
        {
            switch (result)
            {
                case ExecutionResult.IncorectData:
                    Console.WriteLine("You entered incorrect data.");
                    break;
                case ExecutionResult.Instruction:
                    Console.WriteLine(Instruction);
                    break;
                case ExecutionResult.TriangleAdded:
                    Console.WriteLine("Triangle added");
                    break;
                default:
                    break;
            }
        }
    }
}
