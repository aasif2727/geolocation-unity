﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularUnits.Helper
{
    public static class Helper
    {
        public static bool IsRadianType(this string inputVal)
        {
            if (inputVal.Contains("pi"))
                return true;
            else
                return false;
        }
    }
}