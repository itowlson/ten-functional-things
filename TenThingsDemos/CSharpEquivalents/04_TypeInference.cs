using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEquivalents
{
    public static class TypeInference
    {
        public static IEnumerable<TResult> Select<TSource, TResult>(IEnumerable<TSource> xs, Func<TSource, TResult> f)
        {
            foreach (var x in xs)
            {
                yield return f(x);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(IEnumerable<TSource> xs, Func<TSource, IEnumerable<TResult>> f)
        {
            foreach (var x in xs)
            {
                foreach (var y in f(x))
                {
                    yield return y;
                }
            }
        }

        public static void PrintElement<TKey, TValue>(Dictionary<TKey, TValue> dict, TKey key)
        {
            TValue value;
            if (dict.TryGetValue(key, out value))
            {
                Console.WriteLine(value);
            }
            else
            {
                Console.WriteLine("<missing>");
            }
        }
    }
}
