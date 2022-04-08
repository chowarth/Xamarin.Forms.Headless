using System.Collections.Generic;
using Xamarin.Forms;

namespace XF.Headless
{
    public interface IHeadlessApp
    {
        /// <summary>
        /// Invokes the <see cref="Application.OnStart"/> method
        /// </summary>
        void OnStart();

        /// <summary>
        /// Invokes the <see cref="Application.OnSleep"/> method
        /// </summary>
        void OnSleep();

        /// <summary>
        /// Invokes the <see cref="Application.OnResume"/> method
        /// </summary>
        void OnResume();

        /// <summary>
        /// Queries the current <see cref="Application.MainPage"/> view hierarchy for elements that match the supplied
        /// <paramref name="marked"/> value. <paramref name="marked"/> will be matched against <c>AutomationId</c> first
        /// then, depending on the element, <c>Title, Text, FormattedText, Placeholder</c>.
        /// </summary>
        /// <remarks>
        /// Any element that is not visible will NOT be returned
        /// </remarks>
        /// <param name="marked">The value to match</param>
        /// <returns>A read-only list representing the matched elements</returns>
        IReadOnlyList<Element> Query(string marked);
    }
}
