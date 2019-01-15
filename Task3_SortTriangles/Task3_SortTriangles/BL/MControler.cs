using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3_SortTriangles.IntermediatLvl;

namespace Task3_SortTriangles.BL
{
    class MControler
    {
        public MControler(IUI visualizator)
        {
            visualizator.AskForSortedListDesc += GiveSortedList;
            visualizator.DataSenderDesc += AddTriangl;
            visualizator.StartAgainDesc += StartAtFirst;

        
        }

        private bool AddTriangl(string innerString)
        {
            string name;
            double[] sides;
            bool result = false;
            if (ValidateInnerData(innerString,out sides, out name))
            {
                _triangls.Add(new Triangl(name, sides[0], sides[1], sides[2]));
                result = true;
            }
            return result;  
        }

        private bool ValidateInnerData(string innerString,out double[] sides, out string name) //out sides чтоб компилятор не ругался 
        {
            int sideCount = 3;
            name = " ";
            sides = new double[sideCount]; 
            bool result = true;
            //парсим по ,
            char[] splitSymbols = new char[] { ',' };
            string[] TrianglesData = innerString.Split(splitSymbols);
            for (int i = 0; i < TrianglesData.Length; i++)
            {
                char oldSymbols = '.';
                char newSymbols = ',';
                TrianglesData[i] = TrianglesData[i].Replace(oldSymbols, newSymbols);
                oldSymbols = ' ';
                newSymbols = '\0';
                TrianglesData[i] = TrianglesData[i].Replace(oldSymbols, newSymbols);
                oldSymbols = '\t';
                TrianglesData[i] = TrianglesData[i].Replace(oldSymbols, newSymbols);
            }

            int paramCount = 4; 
            if (TrianglesData.Length != paramCount) // как можно заменить??
            {
                result = false;
            }

            if (result)
            {
                name = TrianglesData[0];

                for (int i = 0; i < sideCount; i++)
                {
                    if (!double.TryParse(TrianglesData[i+1],out sides[i]))
                    {
                        result = false;
                        break;
                    }
                }

                //валидация длин
                for (int i = 0; i < sideCount; i++)
                {
                    double sideSum = 0;
                    for (int j = 0; j < sideCount; j++)
                    {
                        if (i != j)
                        {
                            sideSum += sides[j];
                        }        
                    }
                    double sideVerification = sides[i] - sideSum;
                    if (sideVerification >= 0)
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        private List<TrianglILvl> GiveSortedList()
        {
            _triangls.Sort();
            _triangls.Reverse();
            List<TrianglILvl> result = new List<TrianglILvl>();
            foreach (Triangl item in _triangls)
            {
                result.Add(new TrianglILvl(item.Name, item.Square));
            }
            return result;
        }


        private void StartAtFirst()
        {
            _triangls.Clear();
        }

        private List<TrianglILvl> ReturnSorted()//заменить на ienumerable
        {
            _triangls.Sort();
            List<TrianglILvl> result = new List<TrianglILvl>();
            foreach (Triangl item in _triangls)
            {
                result.Add(new TrianglILvl(item.Name, item.Square));
            }
            return result;
        }


        List<Triangl> _triangls = new List<Triangl>();
    }
}
