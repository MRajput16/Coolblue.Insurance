using System.Collections.Generic;
using System.Linq;

namespace Insurance.Common
{
    public static class ListExtensions
    {
        /// <summary>
        /// checks if the given list is null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsEmpty<T>(this IList<T> list)
        {
            return list == null || !list.Any();
        }
    }
}
