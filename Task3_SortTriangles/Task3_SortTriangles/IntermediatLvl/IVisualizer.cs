using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_SortTriangles.IntermediatLvl
{
    public interface IVisualizer
    {
        bool ContinueRequest();
        string AskForData();
        void ReturnAnsver(ExecutionResult result, List<TrianglILvl> roll = null);
    }
}
