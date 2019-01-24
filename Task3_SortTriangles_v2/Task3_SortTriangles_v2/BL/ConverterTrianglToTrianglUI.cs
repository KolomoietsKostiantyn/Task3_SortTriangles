﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3_SortTriangles_v2.Intermediate;

namespace Task3_SortTriangles_v2.BL
{
    class ConverterTrianglToTrianglUI : IConverterTrianglToTrianglUI
    {
        public List<TriangleToUI> ConvertTriangls(List<Triangle> tList)
        {
            List<TriangleToUI> result = new List<TriangleToUI>();
            foreach (Triangle item in tList)
            {
                result.Add(new TriangleToUI(item.Name, item.Square));
            }

            return result;
        }
    }
}
