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
        public void ValidateInputArray_NullReserense_Falfe()
        {
            string[] array = null;

            bool result = _parser.ValidateInputArray(array);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateInputArray_TooShortArray_False()
        {
            string[] array = new string[] { "q", "s" };

            bool result = _parser.ValidateInputArray(array);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateInputArray_TooLongArray_False()
        {
            string[] array = new string[] { "q", "s", "33", " 55", "44" };

            bool result = _parser.ValidateInputArray(array);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateInputArray_OneArrayElementIsNull_False()
        {
            string[] array = new string[] { "q", "s", null, "3" };

            bool result = _parser.ValidateInputArray(array);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateInputArray_OneArrayElementIsWhiteSpace_False()
        {
            string[] array = new string[] { "q", "s", " ", "3" };

            bool result = _parser.ValidateInputArray(array);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateInputArray_OneArrayElementIsEmpty_False()
        {
            string[] array = new string[] { "q", "s", string.Empty, "3" };

            bool result = _parser.ValidateInputArray(array);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateInputArray_ValidData_True()
        {
            string[] array = new string[] { "q", "s", "ds", "ee" };

            bool result = _parser.ValidateInputArray(array);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ConvertToCorrectStringWithoutSeparators_NullReferense_Null()
        {
            string[] array = null;

            string result = _parser.ConvertToCorrectStringWithoutSeparators(array);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ConvertToCorrectStringWithoutSeparators_TooLongArray_Null()
        {
            string[] array = new string[] { "q", "s", "33", " 55", "44" };

            string result = _parser.ConvertToCorrectStringWithoutSeparators(array);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ConvertToCorrectStringWithoutSeparators_TooShortArray_Null()
        {
            string[] array = new string[] { "q", "s" };

            string result = _parser.ConvertToCorrectStringWithoutSeparators(array);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ConvertToCorrectStringWithoutSeparators_OneArrayElementIsNull_Null()
        {
            string[] array = new string[] { "q", "s", null, "3" };

            string result = _parser.ConvertToCorrectStringWithoutSeparators(array);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ConvertToCorrectStringWithoutSeparators_OneArrayElementIsEmpty_Null()
        {
            string[] array = new string[] { "q", "s", string.Empty, "3" };

            string result = _parser.ConvertToCorrectStringWithoutSeparators(array);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ConvertToCorrectStringWithoutSeparators_OneArrayElementIsWhiteSpace_Null()
        {
            string[] array = new string[] { "q", "s", " ", "3" };

            string result = _parser.ConvertToCorrectStringWithoutSeparators(array);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ConvertToCorrectStringWithoutSeparators_AfterArrayRebildBySeparatorIncorectLenth_Null()
        {
            string[] array = new string[] { "q ", ", 13, 32,3,", " fd", " 3 " };

            string result = _parser.ConvertToCorrectStringWithoutSeparators(array);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ConvertToCorrectStringWithoutSeparators_AfterArrayRebildBySeparatorElementIsEmpty_Null()
        {
            string[] array = new string[] { "q ", ",,,", " fd", " 3 " };

            string result = _parser.ConvertToCorrectStringWithoutSeparators(array);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ConvertToCorrectStringWithoutSeparators_AfterArrayRebildBySeparatorElementIsToBig_Null()
        {
            string[] array = new string[] { "q ", ",r,r,r,r,", " fd", " 3 " };

            string result = _parser.ConvertToCorrectStringWithoutSeparators(array);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ConvertToCorrectStringWithoutSeparators_AfterArrayRebildBySeparatorElementIsToLittle_Null()
        {
            string[] array = new string[] { "q ", ",r", " fd", " 3 " };

            string result = _parser.ConvertToCorrectStringWithoutSeparators(array);

            Assert.IsNull(result);
        }

        [TestMethod]
        [DataRow((new string[] { "\t12  .\t5", ",3 .3 3,", "\t\t5.0", ",64" }), "12.5,3.33,5.0,64")]
        [DataRow((new string[] { "n a m e  .\t5", ",vo\trd,", "\t1\t5.0", ",64" }), "name.5,vord,15.0,64")]
        [DataRow((new string[] { "0,0,0,", "33", "33", "33" }), "0,0,0,333333")]
        public void ConvertToCorrectStringWithoutSeparators_ValidData_Ok(string[] inner, string expect)
        {

            string result = _parser.ConvertToCorrectStringWithoutSeparators(inner);

            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void ConvertToCorrectStringWithoutSeparatorsString_NullReferense_Null()
        {
            string inner = null;

            string result = _parser.ConvertToCorrectStringWithoutSeparatorsString(inner);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ConvertToCorrectStringWithoutSeparatorsString_EmptyString_Null()
        {
            string inner = string.Empty;

            string result = _parser.ConvertToCorrectStringWithoutSeparatorsString(inner);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ConvertToCorrectStringWithoutSeparatorsString_WhiteSpace_Null()
        {
            string inner = " ";

            string result = _parser.ConvertToCorrectStringWithoutSeparatorsString(inner);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ConvertToCorrectStringWithoutSeparatorsString_TooFewValue_Null()
        {
            string inner = "33,33";

            string result = _parser.ConvertToCorrectStringWithoutSeparatorsString(inner);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ConvertToCorrectStringWithoutSeparatorsString_TooManyValue_Null()
        {
            string inner = "33,33,33,33,33";

            string result = _parser.ConvertToCorrectStringWithoutSeparatorsString(inner);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ConvertToCorrectStringWithoutSeparatorsString_IncorectSeparatorSequence_Null()
        {
            string inner = "33,,,33 33 33 ";

            string result = _parser.ConvertToCorrectStringWithoutSeparatorsString(inner);

            Assert.IsNull(result);
        }



        [TestMethod]
        [DataRow("12   .5,\t3 . 3\t3 ,5\t.0\t,64", "12.5,3.33,5.0,64")]
        [DataRow("n a me . 5 , v o rd, \t1 5 \t.0,64", "name.5,vord,15.0,64")]
        [DataRow("0  , 0 , 0 , 3\t33\t33\t3", "0,0,0,333333")]
        public void ConvertToCorrectStringWithoutSeparators_ValidData_Ok(string inner, string expect)
        {

            string result = _parser.ConvertToCorrectStringWithoutSeparatorsString(inner);

            Assert.AreEqual(expect, result);
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
        public void SplitStringToValidateParams_EmptyElement_False()
        {
            string str = " ,10,10,15.1";
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
        [DataRow("triangl1,15.1,10,-10")]
        [DataRow("triangl1,0,0,0")]
        [DataRow("triangl1,\t, ,0")]
        [DataRow("triangl1,-15.1,-10,-10")]
        [DataRow("triangl1,-15.1,10,-10")]
        [DataRow("triangl1,1 5. 1,10,10")]
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
        [DataRow(" df ,30,0.10,30", " df ", 30, 0.1, 30)]
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
