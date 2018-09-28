using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularUnits.Helper
{
    public static class GeometryHelper
    {
        public static double ToRadian(this string inputVal)
        {
            return (Math.PI / 180.0) * Convert.ToDouble(inputVal);
        }

        public static double ToDegree(this string inputVal)
        {
            int? slashIdx = null;
            int? pieIdx = null;
            char[] radianArray = inputVal.ToCharArray();
            for (int i=0; i<radianArray.Length;i++)
            {
                if (radianArray[i].Equals("/"))
                {
                    slashIdx = i;
                }
                if (radianArray[i].Equals("pie"))
                {
                    pieIdx = i;
                }
                if (radianArray[i].Equals("pi"))
                {
                    pieIdx = i;
                }
                if (radianArray[i].Equals("π"))
                {
                    pieIdx = i;
                }
            }

            if (!slashIdx.HasValue && pieIdx.HasValue)
            {
                string temp = inputVal.Substring(0, pieIdx.Value);
                return (Math.PI) * Convert.ToDouble(temp);
            }
            if (!slashIdx.HasValue && pieIdx.HasValue)
            {
                string _prefix = inputVal.Substring(0, pieIdx.Value);
                string _suffix = inputVal.Substring(pieIdx.Value, inputVal.Length);
                return ((Math.PI) * Convert.ToDouble(_prefix))/Convert.ToDouble(_suffix);
            }
            if (!slashIdx.HasValue && !pieIdx.HasValue)
            {
                return (Math.PI / 180.0) * Convert.ToDouble(inputVal);
            }
            else
            {
                return (Math.PI / 180.0) * Convert.ToDouble(inputVal);
            }
        }
    }
}
