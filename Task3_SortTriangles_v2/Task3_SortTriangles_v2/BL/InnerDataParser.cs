using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_SortTriangles_v2.BL
{
    public class InnerDataParser : IInnerDataParser
    {
        public bool ValidateInputArray(string[] arr, int requiredLength)
        {
            bool result = true;
            if (arr == null || arr.Length != requiredLength)
            {
                return false;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(arr[i]))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public string ConvertToCorrectStringWithoutSeparators(string[] arr, int elementCount)
        {
            StringBuilder sBuilder = new StringBuilder();
            foreach (string item in arr)
            {
                sBuilder.Append(item);
            }
            sBuilder = sBuilder.Replace(" ",string.Empty);
            sBuilder = sBuilder.Replace("\t", string.Empty);
            string[] newArray = (sBuilder.ToString()).Split(',');
            if (newArray.Length != elementCount)
            {
                throw new ArgumentException("wrong comma count");
            }
            foreach (string item in newArray)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    throw new ArgumentException("Empty element");
                }
            }
            sBuilder.Clear();
            bool separator = true;
            for (int i = 0; i < newArray.Length; i++)
            {
                if (separator)
                {
                    sBuilder.Append(newArray[i]);
                    separator = false;
                }
                else
                {
                    sBuilder.Append(string.Format(",{0}", newArray[i]));
                }
            }

            return (sBuilder.ToString()).TrimEnd();
        }

        public string ConvertToCorrectStringWithoutSeparators(string arr, int elementCount)
        {
            return ConvertToCorrectStringWithoutSeparators(new string[] { arr}, elementCount);
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
            if (double.TryParse(newArray[1], NumberStyles.Number,
            CultureInfo.CreateSpecificCulture("en-US"), out side1))
            {
                if (side1 <= 0)
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            if (result && double.TryParse(newArray[2], NumberStyles.Number,
                    CultureInfo.CreateSpecificCulture("en-US"), out side2))
            {
                if (side2 <= 0)
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            if (result && double.TryParse(newArray[3], NumberStyles.Number,
                    CultureInfo.CreateSpecificCulture("en-US"), out side3))
            {
                if (side3 <= 0)
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }


    }
}
