﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_SortTriangles_v2.Intermediate
{
    public interface IVisualizer
    {
        bool ContinueRequest();
        string AskForData();
        void ReturnMessage(ExecutionResult result);
        void ReturnAnsver( List<TriangleToUI> roll );
    }
}
