using System;

namespace XF.Headless.Helpers
{
    static class ExceptionHelpers
    {
        public static T ThrowIfNull<T>(this T arg, string paramName)
        {
            if (arg is null)
                throw new ArgumentNullException(paramName);

            return arg;
        }
    }
}
