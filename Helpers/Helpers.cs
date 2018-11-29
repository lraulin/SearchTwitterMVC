using System.Collections.Generic;
using System.Linq;

namespace SearchTwitterMVC.Helpers
{
    public static class Helpers
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
        {
            return !(list?.Any() ?? false);
        }
    }
}