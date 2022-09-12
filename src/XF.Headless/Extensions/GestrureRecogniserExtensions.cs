using System.Linq;
using Xamarin.Forms;

namespace XF.Headless.Extensions
{
    internal static class GestrureRecogniserExtensions
    {
        /// <summary>
        /// Invokes any <see cref="TapGestureRecognizer"/> attached to the element
        /// </summary>
        /// <param name="element">The element to invoke <see cref="TapGestureRecognizer"/> on</param>
        /// <returns><see langword="true"/> if a <see cref="TapGestureRecognizer"/> was invoked, <see langword="false"/> otherwise</returns>
        internal static bool InvokeTapGestureRecognisers(this Element element)
        {
            bool invoked = false;

            if (element is View view)
            {
                var tgrs = view.GestureRecognizers.OfType<TapGestureRecognizer>();
                if (tgrs.Any())
                {
                    foreach (var tgr in tgrs)
                        tgr.SendTapped(view);

                    invoked = true;
                }
            }

            return invoked;
        }
    }
}
