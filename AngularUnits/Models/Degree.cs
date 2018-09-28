
namespace AngularUnits.Models
{

    public struct Degree
    {
        private readonly double _value;

        // Construct Degree from Double
        public Degree(double value) => _value = value;

        // Converts Degree to Double
        private double ToDouble() => _value;

        // Implicitly Degree -> Double
        public static implicit operator Degree(double value) => new Degree(value);

        // Implicitly Degree -> Double
        public static implicit operator double(Degree d) => d.ToDouble();

        // Explicitly Degree -> Radian
        public static explicit operator Degree(Radian r) => ConvertAngle.ToDegree(r);

        // Explicitly Degree -> Radian
        public static explicit operator Radian(Degree d) => ConvertAngle.ToRadian(d);
    }

    
}