using System;

namespace DataAccess.MutableTuple
{
    public class MutableTuple<T1, T2, T3>
    {
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }
        public T3 Item3 { get; set; }

        public static implicit operator MutableTuple<T1, T2, T3>(Tuple<T1, T2, T3> tuple)
        {
            return new MutableTuple<T1, T2, T3>
            {
                Item1 = tuple.Item1,
                Item2 = tuple.Item2,
                Item3 = tuple.Item3
            };
        }

        public static implicit operator Tuple<T1, T2, T3>(MutableTuple<T1, T2, T3> mutableTuple)
        {
            return new Tuple<T1, T2, T3>(mutableTuple.Item1,
                mutableTuple.Item2,
                mutableTuple.Item3);
        }
    }
}