using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3_SortTriangles.IntermediatLvl;

namespace Task3_SortTriangles.UI
{
    class ConsoleUI : IVisualizer
    {
        private string Instruction = "Add a triangle in the format <name>, <side length>, <side length>, <side length> " +
                    "if you use floating-point numbers write them through '.'";
        private int accuracy = 3;

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

        public string AskForData()
        {
            Console.WriteLine("Enter the data to create a triangle in the format:  name, side length, side length, side length");
            return Console.ReadLine();
        }

        public void ReturnAnsver(ExecutionResult result, List<TrianglILvl> roll = null)
        {
            switch (result)
            {
                case ExecutionResult.Ok:
                    Console.WriteLine("============= Triangles list: ===============");
                    for (int i = 0; i < roll.Count; i++)
                    {
                        double squere = Math.Round((roll[i].Square));
                        Console.WriteLine(string.Format("{0}. [{1}]: {2} сm", (i + 1), roll[i].Name, squere));
                        Console.ReadKey();
                    }
                    break;
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
