using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGNWebAppCli.Helpers
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Verify collection empty or null
        /// </summary>
    
        public static bool IsCollectionEmptyOrNull<T>(this IEnumerable<T> data)
        {
            return data != null && data.Any();
        }
    }
}
