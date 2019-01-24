using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3_SortTriangles_v2.Intermediate;

namespace Task3_SortTriangles_v2.BL
{
    public interface IConverterTrianglToTrianglUI
    {
        List<TriangleToUI> ConvertTriangls(List<Triangle> tList);
    }
}
