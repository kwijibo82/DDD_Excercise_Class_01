using System;

namespace Common.Domain.Model
{
    public static class Requires
    {

        public static void NotNull<T>(T argument, string argumentName) where T : class
        {
            if (argument == null)
                throw new ArgumentNullException(argumentName);
        }

        public static void NotNullOrEmpty(string argument, string argumentName)
        {
            if (argument == null)
                throw new ArgumentNullException(argumentName);

            if (argument == "")
                throw new ArgumentException(argumentName + " cannot be an empty string", argumentName);
        }

        public static void GreaterThanOrEqualToZero(int argument, string argumentName)
        {
            if (argument < 0)
                throw new ArgumentOutOfRangeException(argumentName, argumentName + " should be >= 0");
        }

        public static void GreaterThanOrEqualToOne(int argument, string argumentName)
        {
            if (argument < 1)
                throw new ArgumentOutOfRangeException(argumentName, argumentName + " should be >= 1");
        }
    }
}