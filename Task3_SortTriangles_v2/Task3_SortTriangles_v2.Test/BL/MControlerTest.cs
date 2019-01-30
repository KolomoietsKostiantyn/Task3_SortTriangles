using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Task3_SortTriangles_v2.BL;
using Task3_SortTriangles_v2.Intermediate;

namespace Task3_SortTriangles_v2.Test.BL
{
    [TestClass]
    public class MControlerTest
    {

        private MControler _controler;
        private Mock<IVisualizer> _visualizer;
        private Mock<ITrianglStorage> _storage;
        private Mock<IInnerDataParser> _innerDataParser;
        private Mock<IConverterTrianglToTrianglUI> _converterTriangl;

        [TestInitialize]
        public void Initialize()
        {
            _visualizer = new Mock<IVisualizer>();
            _storage = new Mock<ITrianglStorage>();
            _innerDataParser = new Mock<IInnerDataParser>();
            _converterTriangl = new Mock<IConverterTrianglToTrianglUI>();
        }

        [TestMethod]
        public void Start_InvalidArray_VisualizerReturnMessageInstruction()
        {
            string[] arr = null;
            _controler = new MControler(_visualizer.Object, _storage.Object, _innerDataParser.Object, _converterTriangl.Object, arr);
            _innerDataParser.Setup(x => x.ValidateInputArray(It.IsAny<string[]>())).Returns(false);
            _controler.Start();

            _visualizer.Verify(x => x.ReturnMessage(It.Is<ExecutionResult>(val => val.Equals(ExecutionResult.Instruction))));
        }

        [TestMethod]
        public void Start_InnerParamCantBeParsedToParam_VisualizerReturnMessageIncorectData()
        {
            string[] arr = null;
            string name;
            double side1;
            double side2;
            double side3;
            _controler = new MControler(_visualizer.Object, _storage.Object, _innerDataParser.Object, _converterTriangl.Object, arr);
            _innerDataParser.Setup(x => x.ValidateInputArray(It.IsAny<string[]>())).Returns(true);
            _innerDataParser.Setup(x => x.ConvertToCorrectStringWithoutSeparators(It.IsAny<string[]>())).Returns("l");
            _innerDataParser.Setup(x => x.ConvertToCorrectStringWithoutSeparatorsString(It.IsAny<string>())).Returns("l");
            _innerDataParser.Setup(x => x.SplitStringToValidateParams(It.IsAny<string>(), out name, out side1, out side2, out side3)).Returns(false);

            _controler.Start();

            _visualizer.Verify(x => x.ReturnMessage(It.Is<ExecutionResult>(val => val.Equals(ExecutionResult.IncorectData))));
        }

        [TestMethod]
        public void Start_InnerParamTrianglCantBeCreated_VisualizerReturnMessageIncorectData()
        {
            string[] arr = null;
            string name = "name";
            double side1 = 1;
            double side2 = 5;
            double side3 = 10;
            _controler = new MControler(_visualizer.Object, _storage.Object, _innerDataParser.Object, _converterTriangl.Object, arr);
            _innerDataParser.Setup(x => x.ValidateInputArray(It.IsAny<string[]>())).Returns(true);
            _innerDataParser.Setup(x => x.ConvertToCorrectStringWithoutSeparators(It.IsAny<string[]>())).Returns("l");
            _innerDataParser.Setup(x => x.ConvertToCorrectStringWithoutSeparatorsString(It.IsAny<string>())).Returns("l");
            _innerDataParser.Setup(x => x.SplitStringToValidateParams(It.IsAny<string>(), out name, out side1, out side2, out side3)).Returns(true);
            _storage
                .Setup(x => x.AddTriangl(It.IsAny<string>(),
                    It.Is<double>(var1 => var1.Equals(side1)),
                    It.Is<double>(var2 => var2.Equals(side2)),
                    It.Is<double>(var3 => var3.Equals(side3)))).Returns(false);

            _controler.Start();

            _visualizer.Verify(x => x.ReturnMessage(It.Is<ExecutionResult>(val => val.Equals(ExecutionResult.IncorectData))));
        }

        [TestMethod]
        public void Start_InnerParamTrianglValid_VisualizerReturnTriangleAdded()
        {
            string[] arr = null;
            string name = "name";
            double side1 = 1;
            double side2 = 5;
            double side3 = 10;
            _controler = new MControler(_visualizer.Object, _storage.Object, _innerDataParser.Object, _converterTriangl.Object, arr);
            _innerDataParser.Setup(x => x.ValidateInputArray(It.IsAny<string[]>())).Returns(true);
            _innerDataParser.Setup(x => x.ConvertToCorrectStringWithoutSeparators(It.IsAny<string[]>())).Returns("l");
            _innerDataParser.Setup(x => x.ConvertToCorrectStringWithoutSeparatorsString(It.IsAny<string>())).Returns("l");
            _innerDataParser.Setup(x => x.SplitStringToValidateParams(It.IsAny<string>(), out name, out side1, out side2, out side3)).Returns(true);
            _storage
                .Setup(x => x.AddTriangl(It.IsAny<string>(),
                    It.Is<double>(var1 => var1.Equals(side1)),
                    It.Is<double>(var2 => var2.Equals(side2)),
                    It.Is<double>(var3 => var3.Equals(side3)))).Returns(true);

            _controler.Start();

            _visualizer.Verify(x => x.ReturnMessage(It.Is<ExecutionResult>(val => val.Equals(ExecutionResult.TriangleAdded))));
        }

        [TestMethod]
        public void Start_VeryfyCallReturnAnsver()
        {
            string[] arr = null;
            _controler = new MControler(_visualizer.Object, _storage.Object, _innerDataParser.Object, _converterTriangl.Object, arr);
            _controler.Start();

            _visualizer.Verify(x => x.ReturnAnsver(It.IsAny<IEnumerable<TriangleToUI>>()));
        }








    }
}
