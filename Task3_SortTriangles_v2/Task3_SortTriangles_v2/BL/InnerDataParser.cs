using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_SortTriangles_v2.BL
{
    class InnerDataParser : IInnerDataParser
    {
        public void ValidateInputArray(string[] arr, int requiredLength)
        {
            
            if (arr == null || arr.Length != requiredLength)
            {
                throw new ArgumentNullException("string[] arr");
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == null)
                {
                    throw new ArgumentNullException("arr["+i+"]");
                }
            }
        }

        public string DeleteSeparatorsFromArr(string[] arr, int requiredLength)
        {
            ValidateInputArray(arr, requiredLength);
            StringBuilder sBuilder = new StringBuilder();
            foreach (string item in arr)
            {
                sBuilder.Append(item);
            }
            sBuilder = sBuilder.Replace(" ",string.Empty);
            sBuilder = sBuilder.Replace("\t", string.Empty);
            string[] newArray = (sBuilder.ToString()).Split(',');
            if (newArray.Length != requiredLength)
            {
                throw new ArgumentException("wrong comma count");
            }
            sBuilder.Clear();
            foreach (string item in newArray)
            {
                sBuilder.Append(item);
            }

            return sBuilder.ToString();
        }

        public string DeleteSeparatorsFromString(string arr, int requiredLength)
        {
            return DeleteSeparatorsFromArr(new string[] { arr }, requiredLength);
        }


        public bool SplitStringToValidateParams(string innerData, out string name, out double side1, out double side2, out double side3)
        {
            bool result = true;
            name = string.Empty;
            side1 = 0.0;
            side2 = 0.0;
            side3 = 0.0;
            string[] newArray = (innerData).Split(',');
            if (newArray.Length != 4)
            {
                return false;
            }
            name = newArray[0];
            if (!double.TryParse(newArray[1], NumberStyles.Number,
            CultureInfo.CreateSpecificCulture("en-US"), out side1))
            {
                if (side1 <= 0)
                {
                    result = false;
                }
            }
            if (result && !double.TryParse(newArray[2], NumberStyles.Number,
                    CultureInfo.CreateSpecificCulture("en-US"), out side2))
            {
                if (side2 <= 0)
                {
                    result = false;
                }
            }
            if (result && !double.TryParse(newArray[3], NumberStyles.Number,
                    CultureInfo.CreateSpecificCulture("en-US"), out side3))
            {
                if (side3 <= 0)
                {
                    result = false;
                }
            }

            return result;
        }


    }
}
