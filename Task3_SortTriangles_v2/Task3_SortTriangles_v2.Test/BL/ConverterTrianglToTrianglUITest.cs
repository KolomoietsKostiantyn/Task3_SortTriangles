using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3_SortTriangles_v2.BL;
using Task3_SortTriangles_v2.Intermediate;
using Task3_SortTriangles_v2.Test.Aditional;

namespace Task3_SortTriangles_v2.Test.BL
{
    [TestClass]
    public class ConverterTrianglToTrianglUITest
    {
        [TestMethod]
        public void ConvertTriangls_Null_Null()
        {
            List<Triangle> tList = null;

            ConverterTrianglToTrianglUI converter = new ConverterTrianglToTrianglUI();
            List<TriangleToUI> result = converter.ConvertTriangls(tList);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ConvertTriangls_Validdata_Null()
        {
            List<Triangle> tList = new List<Triangle>();
            tList.Add(new Triangle("t1",3,4,5)); 
            tList.Add(new Triangle("t2", 6, 8, 10)); 
            tList.Add(new Triangle("t3", 1.5, 2, 2.5)); 

            ConverterTrianglToTrianglUI converter = new ConverterTrianglToTrianglUI();
            List<TriangleToUI> result = converter.ConvertTriangls(tList);

            List<TriangleToUI> expect = new List<TriangleToUI>();
            expect.Add(new TriangleToUI("t1", 6));
            expect.Add(new TriangleToUI("t2", 24));
            expect.Add(new TriangleToUI("t3", 1.5));

            TriangleToUICompare triangleToUICompare = new TriangleToUICompare();

            CollectionAssert.AreEqual(result, expect, triangleToUICompare);
            
        }
    }
}
