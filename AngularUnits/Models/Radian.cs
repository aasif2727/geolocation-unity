namespace AngularUnits.Models
{
    public struct Radian
    {
        private readonly double _value;

        // Construct Degree from Double
        public Radian(double value) => _value = value;

        // Converts Degree to Double
        private double ToDouble() => _value;

        // Implicitly Double -> Radian
        public static implicit operator Radian(double value) => new Radian(value);

        // Implicitly Radian -> Double
        public static implicit operator double(Radian d) => d.ToDouble();
    }
}