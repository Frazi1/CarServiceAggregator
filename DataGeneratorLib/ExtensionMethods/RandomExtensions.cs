using System;
using System.Collections.Generic;
using System.Linq;

namespace DataGeneratorLib.ExtensionMethods
{
    public static class RandomExtensions
    {
        #region IEnumerable

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list)
        {
            Random r = new Random();
            return list.OrderBy(item => r.Next());
        }

        #endregion

        #region NextInt64

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
            byte[] buffer = new byte[8];
            r.NextBytes(buffer);
            long result = BitConverter.ToInt64(buffer, 0);
            return Math.Abs(result % (maxValue - minValue)) + minValue;
        }

        #endregion

        #region NextDateTime

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

        #endregion
    }
}