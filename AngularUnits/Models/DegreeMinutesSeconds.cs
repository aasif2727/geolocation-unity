using System;

namespace AngularUnits.Models
{
    public struct DegreeMinutesSeconds : IEquatable<DegreeMinutesSeconds>
    {
        public readonly double Degrees;
        public readonly double Minutes;
        public readonly double Seconds;

        public DegreeMinutesSeconds(double degree, double minute, double second)
        {
            Degrees = Math.Floor(degree);
            Minutes = Math.Abs(Math.Floor(minute));
            Seconds = Math.Abs(second);
        }

        public bool Equals(DegreeMinutesSeconds other) => (Math.Abs(other.Degrees - Degrees) < double.Epsilon) &&
                                                          (Math.Abs(other.Minutes - Minutes) < double.Epsilon) &&
                                                          (Math.Abs(other.Seconds - Seconds) < double.Epsilon);
    }
}