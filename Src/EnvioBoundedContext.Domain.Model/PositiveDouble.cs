using System;

namespace EnvioBoundedContext.Domain.Model
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

        double value;

        public PositiveDouble(double newValue)
        {
            if (double.IsNegativeInfinity(newValue))
                throw new NotSupportedException();

            value = newValue < MinValue ? MinValue.value : newValue;
        }

        public static implicit operator double(PositiveDouble d)
        {
            return d.value;
        }

        public static implicit operator PositiveDouble(double d)
        {
            return new PositiveDouble(d);
        }

        public static bool operator <(PositiveDouble a, PositiveDouble b)
        {
            return a.value < b.value;
        }

        public static bool operator >(PositiveDouble a, PositiveDouble b)
        {
            return a.value > b.value;
        }

        public static bool operator ==(PositiveDouble a, PositiveDouble b)
        {
            return a.value == b.value;
        }

        public static bool operator !=(PositiveDouble a, PositiveDouble b)
        {
            return a.value != b.value;
        }

        public static bool operator <=(PositiveDouble a, PositiveDouble b)
        {
            return a.value <= b.value;
        }

        public static bool operator >=(PositiveDouble a, PositiveDouble b)
        {
            return a.value >= b.value;
        }

        public override bool Equals(object a)
        {
            return !(a is PositiveDouble) ? false : this == (PositiveDouble)a;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
