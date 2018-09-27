using Geolocation.Api.Unity.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geolocation.Api.Unity.Provider.IFactory
{
    public interface IGeolocationOperator
    {
        double DegreesToRadians(double degrees);
        double RadiansToDegrees(double radians);
        double GradsToRadians(double grads);
        double RadiansToGrads(double radians);
        double DegreesToGrads(double degrees);
        double GradsToDegrees(double grads);
        double Cos(double x);
        double Sin(double x);
        double Tan(double x);
        double Sec(double x);
        double Csc(double x);
        double Cot(double x);
        double GetAngleOfLineBetweenTwoPoints(PointF p1, PointF p2);
        Direction GetDirection(Point start, Point end);
    }
}
