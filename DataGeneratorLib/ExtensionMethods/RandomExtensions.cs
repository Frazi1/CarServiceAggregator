using System;

namespace DataGeneratorLib.ExtensionMethods
{
    public static class RandomExtensions
    {
        public static long NextInt64(this Random r)
        {
            return r.NextInt64(long.MinValue, long.MaxValue);
        }

        public static long NextInt64(this Random r, long minValue)
        {
            return r.NextInt64(minValue, long.MaxValue);
        }

        public static long NextInt64(this Random r, long minValue, long maxValue)
        {
            var buffer = new byte[8];
            r.NextBytes(buffer);
            var result = BitConverter.ToInt64(buffer, 0);
            return Math.Abs(result % (maxValue - minValue)) + minValue;
        }

        public static DateTime NextDateTime(this Random r)
        {
            return r.NextDateTime(DateTime.MinValue, DateTime.MaxValue);
        }

        public static DateTime NextDateTime(this Random r, int minYear)
        {
            return r.NextDateTime(new DateTime(minYear));
        }

        public static DateTime NextDateTime(this Random r, DateTime minDateTime)
        {
            return r.NextDateTime(minDateTime, DateTime.MaxValue);
        }

        public static DateTime NextDateTime(this Random r, DateTime minDateTime, DateTime maxDateTime)
        {
            return DateTime.FromBinary(r.NextInt64(minDateTime.Ticks, maxDateTime.Ticks));
        }
    }
}