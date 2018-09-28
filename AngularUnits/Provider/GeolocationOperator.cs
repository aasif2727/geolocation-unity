using AngularUnits.Models;
using AngularUnits.Provider.IAngularUnit;
using System;
using System.Drawing;
using AngularUnits.Helper;
using System.Text.RegularExpressions;

namespace AngularUnits.Provider
{
    public class GeolocationOperator : IGeolocationOperator
    {
        public double GenericEvalutor(string inputVal)
        {
            string[] genericArray = null;
            string oprandType = string.Empty;
            double result = 0;
            if (inputVal.Contains(",") || inputVal.Contains("+") || inputVal.Contains(" "))
            {
                genericArray = inputVal.Split(new char[] { ',', '+', ' ' });
                foreach (string str in genericArray)
                {
                    result += CheckType(str).Equals("radian") ? EvaluateRadian(str) : EvaluateDegree(str);
                }
                return result;
            }
            else
            {
                return CheckType(inputVal).Equals("radian") ? EvaluateRadian(inputVal) : EvaluateDegree(inputVal);
            }
        }

        public double DegreesToRadians(string degrees)
        {
            string[] degArray = null;
            double result = 0;
            if (degrees.Contains(",") || degrees.Contains("+") || degrees.Contains(" "))
            {
                degArray = degrees.Split(new char[] {',','+',' '});
                foreach (string str in degArray)
                {
                    result += EvaluateDegree(str);
                }
                return result;
            }
            else
            {
                return EvaluateDegree(degrees);
            }
        }

        public double RadiansToDegrees(string radians)
        {
            string trimmedInput = string.Empty;
            string[] radArray = null;
            double result = 0;
            if (radians.Contains(",") || radians.Contains("+") || radians.Contains(" "))
            {
                radArray = radians.Split(new char[] { ',', '+', ' ' });
                foreach (string str in radArray)
                {
                    result += EvaluateRadian(str);
                }
                return result;
            }
            else
            {
                return EvaluateRadian(radians);
            }
        }

        internal double EvaluateDegree(string degrees)
        {
            if (degrees.Contains("degree"))
            {
                return degrees.Replace("degree", "").Trim().ToRadian();
            }
            if (degrees.Contains("deg"))
            {
                return degrees.Replace("deg", "").Trim().ToRadian();
            }
            else
            {
                return degrees.ToRadian();
            }
        }

        internal double EvaluateRadian(string radians)
        {
            string trimmedInput = string.Empty;
            if (radians.Contains("radian"))
            {
                trimmedInput = radians.Replace("radian", "").Trim();
            }
            if (radians.Contains("rad"))
            {
                trimmedInput = radians.Replace("rad", "").Trim();
            }
            else
            {
                trimmedInput = radians.Trim();
            }
            return trimmedInput.ToDegree();
        }

        internal string CheckType(string typeChk)
        {
            if (typeChk.Contains("radian") || typeChk.Contains("rad"))
            {
                return "radian";
            }
            if (typeChk.Contains("degree") || typeChk.Contains("deg"))
            {
                return "degree";
            }
            else
            {
                return string.Empty;
            }        
        }

        public double GradsToRadians(double grads)
        {
            return (grads / 200.0) * Math.PI;
        }

        public double RadiansToGrads(double radians)
        {
            return (radians / Math.PI) * 200.0;
        }

        public double DegreesToGrads(double degrees)
        {
            return (degrees / 9.0) * 10.0;
        }

        public double GradsToDegrees(double grads)
        {
            return (grads / 10.0) * 9.0;
        }

        public double Sec(double x)
        {
            return (1.0 / Math.Cos(x));
        }

        public double Csc(double x)
        {
            return (1.0 / Math.Sin(x));
        }

        public double Cot(double x)
        {
            return (Math.Cos(x) / Math.Sin(x));
        }

        public string DegreesToCardinal(double degrees)
        {
            string[] cardinals = { "North", "NorthEast", "East", "SouthEast", "South", "SouthWest", "West", "NorthWest", "North" };
            return cardinals[(int)Math.Round(((double)degrees % 360) / 45)];
        }

        public double GetAngleOfLineBetweenTwoPoints(PointF p1, PointF p2)
        {
            var xDiff = p2.X - p1.X;
            var yDiff = p2.Y - p1.Y;
            return Math.Atan2(yDiff, xDiff) * (180 / Math.PI);
        }

        private static readonly double TanPiDiv8 = Math.Sqrt(2.0) - 1.0;
        public Directions GetDirection(Point start, Point end)
        {
            double dx = end.X - start.X;
            double dy = end.Y - start.Y;

            if (Math.Abs(dx) > Math.Abs(dy))
            {
                if (Math.Abs(dy / dx) <= TanPiDiv8)
                {
                    return dx > 0 ? Directions.East : Directions.West;
                }

                if (dx > 0)
                {
                    return dy > 0 ? Directions.Northeast : Directions.Southeast;
                }

                return dy > 0 ? Directions.Northwest : Directions.Southwest;
            }

            if (!(Math.Abs(dy) > 0)) return Directions.Undefined;
            if (Math.Abs(dx / dy) <= TanPiDiv8)
            {
                return dy > 0 ? Directions.North : Directions.South;
            }

            if (dy > 0)
            {
                return dx > 0 ? Directions.Northeast : Directions.Northwest;
            }

            return dx > 0 ? Directions.Southeast : Directions.Southwest;

        }

        public double Cos(double x)
        {
            return Math.Cos(x);
        }

        public double Sin(double x)
        {
            return Math.Sin(x);
        }

        public double Tan(double x)
        {
            return Math.Tan(x);
        }

    }
}