using System;
using Xamarin.Forms;
using XF.Headless.Queries;

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
        /// Queries the current view hierarchy for an element that matches the supplied <paramref name="marked"/> value.
        /// Elements will be matched against <c>AutomationId</c> first, then depending on the element, <c>Title, Text, FormattedText, Placeholder</c>.
        /// </summary>
        /// <remarks>
        /// Only visible elements will be returned.
        /// </remarks>
        /// <param name="marked">The value to match</param>
        /// <returns>The first element that matches <paramref name="marked"/>.</returns>
        Element Query(string marked);

        /// <summary>
        /// Queries the current view hierarchy for an element that matches the supplied <paramref name="query"/>.
        /// </summary>
        /// <remarks>
        /// Only visible elements will be returned.
        /// </remarks>
        /// <param name="query"></param>
        /// <returns>The first element matched by <paramref name="query"/>.</returns>
        Element Query(Func<IMarkedQuery, ElementQuery> query);

        /// <summary>
        /// Taps the first element found that matches the supplied <paramref name="marked"/> value.
        /// </summary>
        /// <remarks>
        /// Only visible elements can be tapped.
        /// </remarks>
        /// <exception cref="System.InvalidOperationException">Thrown when the tappable element command is null</exception>
        /// <param name="marked">The value to match</param>
        void Tap(string marked);
    }
}
