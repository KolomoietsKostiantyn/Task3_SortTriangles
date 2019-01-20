using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3_SortTriangles.IntermediatLvl;

namespace Task3_SortTriangles.BL
{
    class MControler
    {
        private IVisualizer _visualizator;
        private ILogick _logick;
        private string[] _arr;

        public MControler(IVisualizer visualizator, string [] arr)
        {
            _arr = arr;
            _visualizator = visualizator;
            _logick = new Logick();       
        }

        public void Start()
        {
            ProcessingInner(_arr);
            string dataAsk;
            string name;
            double side1;
            double side2;
            double side3;
            do
            {
                bool flag = true;
                do
                {
                    dataAsk = _visualizator.AskForData();
                    if (StringToParams(dataAsk, out name, out side1, out side2, out side3))
                    {
                        if (_logick.addTriangl(name, side1, side2, side3))
                        {
                            flag = false;
                        }
                        else
                        {
                            _visualizator.ReturnAnsver(ExecutionResult.IncorectData);
                        }
                    }
                    else
                    {
                        _visualizator.ReturnAnsver(ExecutionResult.IncorectData);
                    }
                } while (flag);

            } while (_visualizator.ContinueRequest());
            List<Triangle> tList = _logick.GetReversSortedList();
            _visualizator.ReturnAnsver( ExecutionResult.Ok, ReturnAnswer(tList));
        }

        private List<TriangleILvl> ReturnAnswer(List<Triangle> tList)
        {
            List<TriangleILvl> result = new List<TriangleILvl>();
            foreach (Triangle item in tList)
            {
                result.Add(new TriangleILvl(item.Name, item.Square));
            }

            return result;
        }

        private bool StringToParams(string str, out string name, out double side1, out double side2, out double side3)
        {
            bool result = true;
            name = string.Empty;
            side1 = 0.0;
            side2 = 0.0;
            side3 = 0.0;
            string[] innerArr = (str).Split(',');
            if (innerArr.Length != (int)TrianglParams.RequiredToCreate)
            {
                return false;
            }
            for (int i = 1; i < innerArr.Length; i++)
            {
                innerArr[i] = innerArr[i].Replace(" ", string.Empty).Replace("\t", string.Empty);
            }
            name = innerArr[(int)TrianglParams.Name];
            if (!double.TryParse(innerArr[(int)TrianglParams.Side1], NumberStyles.Number,
                    CultureInfo.CreateSpecificCulture("en-US"), out side1))
            {
                result = false;
            }
            if (result && !double.TryParse(innerArr[(int)TrianglParams.Side2], NumberStyles.Number,
                    CultureInfo.CreateSpecificCulture("en-US"), out side2))
            {
                result = false;
            }
            if (result && !double.TryParse(innerArr[(int)TrianglParams.Side3], NumberStyles.Number,
                    CultureInfo.CreateSpecificCulture("en-US"), out side3))
            {
                result = false;
            }

            return result;
        }

        private void ProcessingInner(string[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                _visualizator.ReturnAnsver(ExecutionResult.Instruction);
                return;
            }
            string name;
            double side1;
            double side2;
            double side3;
            if (!ArrToTrianglParams(arr, out name, out side1, out side2, out side3) ||
                    !_logick.addTriangl( name, side1, side2, side3))
            {
                _visualizator.ReturnAnsver(ExecutionResult.Instruction);
            }
            else
            {
                _visualizator.ReturnAnsver(ExecutionResult.TriangleAdded);
            }
        }

        private bool ArrToTrianglParams(string[] arr, out string name, out double side1, out double side2, out double side3)
        {
            StringBuilder inner = new StringBuilder();
            foreach (string item in arr)
            {
                inner.Append(item);
            }

            return StringToParams(inner.ToString(), out name, out side1, out side2, out side3);
        }
    }
}
