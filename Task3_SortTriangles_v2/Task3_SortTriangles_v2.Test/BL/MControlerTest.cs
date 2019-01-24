using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Task3_SortTriangles_v2.BL;
using Task3_SortTriangles_v2.Intermediate;
using Task3_SortTriangles_v2.Test.Aditional;

namespace Task3_SortTriangles_v2.Test.BL
{
    [TestClass]
    public class MControlerTest
    {
        [TestMethod]
        public void TryAddTriangl_CallVisualizatorReturnMessageTriangleAdded_Success()
        {
            Mock<IFactoryBLInitializer> iFactory = new Mock<IFactoryBLInitializer>();
            Mock<IVisualizer> iv = new Mock<IVisualizer>();
            Mock<IInnerDataParser> innerDataParser = new Mock<IInnerDataParser>();

            MControlerMod mt = new MControlerMod(iFactory.Object, iv.Object, It.IsAny<string[]>());

            innerDataParser.Setup(x => x.SplitStringToValidateParams(It.IsAny<string>, It.IsAny<string>, It.IsAny<double>, It.IsAny<double>,out It.IsAny<double>)).


        }
    }
}
