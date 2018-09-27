using Geolocation.Api.Unity.Models;
using Geolocation.Api.Unity.Provider.IFactory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Geolocation.Api.Unity.Provider
{
    public class GeolocationOperator: IGeolocationOperator
    {
        public double DegreesToRadians(double degrees)
        {
            return (Math.PI / 180.0) * degrees;
        }

        public double RadiansToDegrees(double radians)
        {
            return (180.0 / Math.PI) * radians;
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

        public double GetAngleOfLineBetweenTwoPoints(PointF p1, PointF p2)
        {
            float xDiff = p2.X - p1.X;
            float yDiff = p2.Y - p1.Y;
            return Math.Atan2(yDiff, xDiff) * (180 / Math.PI);
        }

        static readonly double tan_Pi_div_8 = Math.Sqrt(2.0) - 1.0;
        public Direction GetDirection(Point start, Point end)
        {
            double dx = end.X - start.X;
            double dy = end.Y - start.Y;

            if (Math.Abs(dx) > Math.Abs(dy))
            {
                if (Math.Abs(dy / dx) <= tan_Pi_div_8)
                {
                    return dx > 0 ? Direction.East : Direction.West;
                }

                else if (dx > 0)
                {
                    return dy > 0 ? Direction.Northeast : Direction.Southeast;
                }
                else
                {
                    return dy > 0 ? Direction.Northwest : Direction.Southwest;
                }
            }
            else if (Math.Abs(dy) > 0)
            {
                if (Math.Abs(dx / dy) <= tan_Pi_div_8)
                {
                    return dy > 0 ? Direction.North : Direction.South;
                }
                else if (dy > 0)
                {
                    return dx > 0 ? Direction.Northeast : Direction.Northwest;
                }
                else
                {
                    return dx > 0 ? Direction.Southeast : Direction.Southwest;
                }
            }
            else
            {
                return Direction.Undefined;
            }

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