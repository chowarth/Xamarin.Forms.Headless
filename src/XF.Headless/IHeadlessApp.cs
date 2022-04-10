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
        /// Only visible elements will be returned.
        /// </remarks>
        /// <param name="marked">The value to match</param>
        /// <returns>A read-only list representing the matched elements</returns>
        IReadOnlyList<Element> Query(string marked);

        /// <summary>
        /// Taps the first element found that matches the supplied <paramref name="marked"/> value.
        /// </summary>
        /// <remarks>
        /// Only visible elements can be tapped.
        /// </remarks>
        /// <exception cref="System.InvalidOperationException">Thrown when the tappable element command is null</exception>
        /// <param name="marked">The value to match</param>
        public void Tap(string marked);
    }
}
