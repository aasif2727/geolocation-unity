using System;

namespace Geolocation.Api.Unity.Models
{
    public static class ConvertAngle
    {
        public static Degree ToDegree(Radian radians)
        {
            return radians * 180.0 / Math.PI;
        }

        public static Degree ToDegree(DegreeMinutesSeconds dms)
        {
            // todo seems sign problem here
            return dms.Degrees + dms.Minutes / 60 + dms.Seconds / 3600;
        }

        public static Radian ToRadian(Degree degrees)
        {
            return degrees * Math.PI / 180.0;
        }

        public static Radian ToRadian(DegreeMinutesSeconds dms)
        {
            return ToRadian(dms.Degrees + dms.Minutes / 60 + dms.Seconds / 3600);
        }

        public static DegreeMinutesSeconds ToDegreeMinutesSeconds(Radian radian)
        {
            return ToDDegreeMinutesSeconds(ToDegree(radian));
        }

        public static DegreeMinutesSeconds ToDDegreeMinutesSeconds(Degree degree)
        {
            var degrees = Math.Floor(degree);
            var rem = (degree - degrees) * 60.0;
            var minutes = Math.Floor(rem);
            var seconds = (rem - minutes) * 60.0;

            return new DegreeMinutesSeconds(degrees, minutes, seconds);
        }

        public static string ToString(Radian radian, AngleFormat format, int precision)
        {
            switch (format)
            {
                case AngleFormat.Radians:
                {
                    var formStr = "{0:F" + precision + "}";

                    return string.Format(formStr, radian);
                }
                case AngleFormat.Degrees:
                case AngleFormat.DegreesMinutes:
                case AngleFormat.DegreesMinutesSeconds:
                    return ToString((Degree)radian, format, precision);
                default:
                    throw new NotImplementedException();
            }
        }


        public static string ToString(Degree degree, AngleFormat format, int precision)
        {
            //   DegreeMinutesSeconds dms = ToDDegreeMinutesSeconds(degree);
            switch (format)
            {

                // todo use precision
                case AngleFormat.Degrees:
                case AngleFormat.DegreesMinutes:
                case AngleFormat.DegreesMinutesSeconds:
                    return ToString(ToDDegreeMinutesSeconds(degree), format, precision);
                case AngleFormat.Radians:
                    return ToString((Radian)degree, format, precision);
                default:
                    throw new ArgumentOutOfRangeException(nameof(format), format, null);
            }
        }

        public static string ToString(DegreeMinutesSeconds dms, AngleFormat format, int precision)
        {
            switch (format)
            {
                // todo here do we need to combine min and sec ??? or we need diffrent format option
                case AngleFormat.Degrees:
                    return string.Format("{0:D}°", dms.Degrees);
                case AngleFormat.DegreesMinutes:
                    return string.Format("{0:D}°{1:D}'", dms.Degrees, dms.Minutes);
                case AngleFormat.DegreesMinutesSeconds:
                    var secondsPrecisionFormat = "F" + Math.Abs(precision).ToString("D");

                    //string d = dms.Degrees.ToString("");

                    //CultureInfo currentCulture = CultureInfo.CurrentCulture;
                    var stringFormat = "{0:F0}° {1:F0}' {2:" + secondsPrecisionFormat + "}\"";
                    return string.Format(stringFormat, dms.Degrees, dms.Minutes, dms.Seconds);

                case AngleFormat.Radians:
                    // todo convert to radians ??
                    break;
            }

            throw new ArgumentOutOfRangeException("format");
        }
    }
}