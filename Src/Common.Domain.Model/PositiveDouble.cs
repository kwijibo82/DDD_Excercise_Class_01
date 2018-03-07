using System;

namespace Common.Domain.Model
{
    public class PositiveDouble
    {
        /// <summary>
        /// Equivalent to <see cref="double.Epsilon"/>.
        /// </summary>
        public static PositiveDouble Epsilon = double.Epsilon;

        /// <summary>
        /// Represents the smallest possible value of <see cref="PositiveDouble "/> (0).
        /// </summary>
        public static PositiveDouble MinValue = 0d;

        /// <summary>
        /// Represents the largest possible value of <see cref="PositiveDouble "/> (equivalent to <see cref="double.MaxValue"/>).
        /// </summary>
        public static PositiveDouble MaxValue = double.MaxValue;

        /// <summary>
        /// Equivalent to <see cref="double.NaN"/>.
        /// </summary>
        public static PositiveDouble NaN = double.NaN;

        /// <summary>
        /// Equivalent to <see cref="double.PositiveInfinity"/>.
        /// </summary>
        public static PositiveDouble PositiveInfinity = double.PositiveInfinity;

        public double Value { get; }

        public PositiveDouble(double value)
        {
            if (double.IsNegativeInfinity(value))
                throw new NotSupportedException();

            Value = value < 0d ? 0d : value;
        }

        public static implicit operator double(PositiveDouble d)
        {
            return d.Value;
        }

        public static implicit operator PositiveDouble(double d)
        {
            return new PositiveDouble(d);
        }

        public static bool operator <(PositiveDouble a, PositiveDouble b)
        {
            return a.Value < b.Value;
        }

        public static bool operator >(PositiveDouble a, PositiveDouble b)
        {
            return a.Value > b.Value;
        }

        public static bool operator ==(PositiveDouble a, PositiveDouble b)
        {
            return a.Value == b.Value;
        }

        public static bool operator !=(PositiveDouble a, PositiveDouble b)
        {
            return a.Value != b.Value;
        }

        public static bool operator <=(PositiveDouble a, PositiveDouble b)
        {
            return a.Value <= b.Value;
        }

        public static bool operator >=(PositiveDouble a, PositiveDouble b)
        {
            return a.Value >= b.Value;
        }

        public override bool Equals(object a)
        {
            return !(a is PositiveDouble) ? false : this == (PositiveDouble)a;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
