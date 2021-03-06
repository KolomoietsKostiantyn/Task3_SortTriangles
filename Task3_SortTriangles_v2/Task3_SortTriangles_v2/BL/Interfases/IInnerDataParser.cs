﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_SortTriangles_v2.BL
{
    public interface IInnerDataParser
    {
        bool ValidateInputArray(string [] arr);
        string ConvertToCorrectStringWithoutSeparators(string[] arr);
        string ConvertToCorrectStringWithoutSeparatorsString(string arr);
        bool SplitStringToValidateParams(string arr, out string name, out double side1, out double side2, out double side3);
    }
}
