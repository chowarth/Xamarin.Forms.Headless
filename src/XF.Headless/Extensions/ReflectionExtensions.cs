using System.Linq;
using System.Reflection;

namespace XF.Headless.Extensions
{
    static class ReflectionExtensions
    {
        static readonly BindingFlags _bindingFlags = BindingFlags.FlattenHierarchy | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static;

        internal static void Invoke(this object obj, string methodName, params object[] parameters)
        {
            foreach (var method in obj.GetType().GetMethods(_bindingFlags))
            {
                if (method.Name.Split('.').Last() == methodName && method.GetParameters().Length == parameters.Length)
                {
                    method.Invoke(obj, parameters);
                }
            }
        }
    }
}
