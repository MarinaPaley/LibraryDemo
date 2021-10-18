using System.Collections.Generic;

namespace Staff.Extensions
{
    public static class IEnumerableExtension
    {
        public static string Join<T>(this IEnumerable<T> collection, string separator = ", ") => string.Join(separator, collection);
    }
}
