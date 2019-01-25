using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3_SortTriangles_v2.BL;

namespace Task3_SortTriangles_v2.Test.BL
{
    [TestClass]
    public class InnerDataParserTest
    {
        InnerDataParser _parser;

        [TestInitialize]
        public void Initilize()
        {
            _parser = new InnerDataParser(); ;
        }

        [TestMethod]
        public void ValidateInputArray_NullReserense_falfe()
        {
            string[] array = null;
            int lentgh = 0;

            bool result = _parser.ValidateInputArray(array, lentgh);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateInputArray_IncorectLenth_false()
        {
            string[] array = new string[] { "q", "s" };
            int lentgh = 3;


            bool result = _parser.ValidateInputArray(array, lentgh);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateInputArray_OneArrayElementIsNull_false()
        {
            string[] array = new string[] { "q", "s", null };
            int lentgh = 3;

            bool result = _parser.ValidateInputArray(array, lentgh);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateInputArray_ValidData_true()
        {
            string[] array = new string[] { "q", "s", "ds" };
            int lentgh = 3;

            bool result = _parser.ValidateInputArray(array, lentgh);

            Assert.IsTrue(result);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ConvertToCorrectStringWithoutSeparatorsArray_ManyCommas_Error()
        {
            string[] array = new string[] { "q,", ",s,", "ds" };
            int separators = 5;

            _parser.ConvertToCorrectStringWithoutSeparators(array, separators);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ConvertToCorrectStringWithoutSeparatorsArray_FewCommas_Error()
        {
            string[] array = new string[] { "q,", ",s,", "ds" };
            int separators = 1;

            _parser.ConvertToCorrectStringWithoutSeparators(array, separators);
        }

        [TestMethod]
        public void ConvertToCorrectStringWithoutSeparatorsArray_ValidData_Ok()
        {
            string[] array = new string[] { "q\t", ",  s ,", "d s", "\t,\t1 . 23" };
            string expected = "q,s,ds,1.23";
            int lenth = 4;

            string result = _parser.ConvertToCorrectStringWithoutSeparators(array, lenth);

            Debug.Write(expected);
            Debug.Write("//");
            Debug.Write(result);

            Assert.AreEqual(expected, result);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ConvertToCorrectStringWithoutSeparatorsArray_IncorectSeparatorsSequence_Error()
        {
            string[] array = new string[] { "q,", ",s,", "ds" };
            int separators = 4;

            _parser.ConvertToCorrectStringWithoutSeparators(array, separators);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ConvertToCorrectStringWithoutSeparatorsString_ManyCommas_Error()
        {
            string str = "q,, ,s, ds";
            int separators = 5;

            _parser.ConvertToCorrectStringWithoutSeparators(str, separators);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ConvertToCorrectStringWithoutSeparatorsString_FewCommas_Error()
        {
            string str =  "q,  s ds" ;
            int separators = 3;

            _parser.ConvertToCorrectStringWithoutSeparators(str, separators);
        }

        [TestMethod]
        public void ConvertToCorrectStringWithoutSeparatorsString_ValidData_Ok()
        {
            string str =  "q\t,  s ,d s\t,\t1 . 23" ;
            string expected = "q,s,ds,1.23";
            int lenth = 4;

            string result = _parser.ConvertToCorrectStringWithoutSeparators(str, lenth);

            Assert.AreEqual(expected, result);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ConvertToCorrectStringWithoutSeparatorsString_IncorectSeparatorsSequence_Error()
        {
            string str = "q,,,sds";
            int separators = 4;

            _parser.ConvertToCorrectStringWithoutSeparators(str, separators);
        }

        [TestMethod]
        public void SplitStringToValidateParams_ManyParams_False()
        {
            string str ="triangl1,15.1,15.1,15.1,15.1";
            string name;
            double side1;
            double side2;
            double side3;

            bool result = _parser.SplitStringToValidateParams(str, out name, out side1, out side2, out side3);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SplitStringToValidateParams_FewParams_False()
        {
            string str = "triangl1,15.1";
            string name;
            double side1;
            double side2;
            double side3;

            bool result = _parser.SplitStringToValidateParams(str, out name, out side1, out side2, out side3);

            Assert.IsFalse(result);
        }


        [TestMethod]
        [DataRow("triangl1,-15.1,10,10")]
        [DataRow("triangl1,15.1,-10,10")]
        [DataRow("triangl1,0,0,0")]
        [DataRow("triangl1,-15.1,-10,-10")]
        [DataRow("triangl1,-15.1,10,-10")]
        [DataRow("triangl1,1 5. 1,10,10")]
        public void SplitStringToValidateParams_IncorectSides_False(string str)
        {
            string name;
            double side1;
            double side2;
            double side3;

            bool result = _parser.SplitStringToValidateParams(str, out name, out side1, out side2, out side3);

            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow("triangl1,15.1,10,10", "triangl1", 15.1, 10.0, 10.0)]
        [DataRow(" df ,0.1,0.10,1.10", " df ", 0.1, 0.1, 1.1)]
        public void SplitStringToValidateParams_ValidData_True(string str, string requestName, double requestSide1, double requestSide2, double requestSide3)
        {
            string name;
            double side1;
            double side2;
            double side3;

            bool result = _parser.SplitStringToValidateParams(str, out name, out side1, out side2, out side3);

            Assert.AreEqual(name,requestName);
            Assert.AreEqual(side1,requestSide1);
            Assert.AreEqual(side2, requestSide2);
            Assert.AreEqual(side3, requestSide3);
        }


    }
}
