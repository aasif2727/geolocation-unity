﻿using AngularUnits.Models;
using AngularUnits.Provider.IAngularUnit;
using System;
using System.Drawing;
using AngularUnits.Helper;

namespace AngularUnits.Provider
{
    public class GeolocationOperator : IGeolocationOperator
    {
        public double DegreesToRadians(string degrees)
        {
            return (Math.PI / 180.0) * Convert.ToDouble(degrees);
        }

        public double RadiansToDegrees(string radians)
        {
            return (180.0 / Math.PI) * Convert.ToDouble(radians);
        }

        public double DegreeRadianOperator(string inputVal)
        {
            bool isRadian = inputVal.IsRadianType();
            if (isRadian)
            {
                return (180.0 / Math.PI) * Convert.ToDouble(inputVal);
            }
            else
            {
                return (Math.PI / 180.0) * Convert.ToDouble(inputVal);
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