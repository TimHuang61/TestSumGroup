using System;
using System.Collections.Generic;
using System.Linq;

namespace HW_SumGroupCalculator
{
    public static class EnumerableExtensoions
    {
        public static IEnumerable<int> CalculateSumGroup<T>(this IEnumerable<T> source, int size, Func<T, int> func)
        {
            if (size < 1 || source == null || !source.Any())
            {
                yield break;
            }

            for (var i = 0; i < source.Count(); i += size)
            {
                yield return source.Skip(i).Take(size).Sum(func);
            }
        }
    }
}