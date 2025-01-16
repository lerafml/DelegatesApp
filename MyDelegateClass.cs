using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesApp
{
    public static class MyDelegateClass
    {
        public static T GetMax<T>(this IEnumerable collection, Func<T, float> convertToNumber) where T : class
        {
            List<float> numberList = new List<float>();
            T result;
            foreach (var item in collection.AsParallel())
            {
                numberList.Add(convertToNumber((T)item));
            }

            IEnumerator enumerator = collection.GetEnumerator();
            enumerator.Reset();
            enumerator.MoveNext();
            while (convertToNumber((T)enumerator.Current) != numberList.Max())
            {
                enumerator.MoveNext();
            }
            return (T)enumerator.Current;
        }

        public static float convertToNumber<T>(T obj) where T : class
        {
            return obj == null ? 0 : obj.ToString().Length;
        }
    }
}
