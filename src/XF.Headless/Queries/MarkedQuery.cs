using System;
using System.Linq;
using Xamarin.Forms;
using XF.Headless.Extensions;

namespace XF.Headless.Queries
{
    public sealed class MarkedQuery : BaseElementQuery
    {
        internal MarkedQuery(Element element)
            : base(element)
        {
        }

        /// <summary>
        /// Finds an element that matches the <paramref name="marked"/> value.
        /// Elements will be matched against <c>AutomationId</c> first, then depending on the element, <c>Title, Text, FormattedText, Placeholder</c>.
        /// </summary>
        /// <remarks>
        /// Only visible elements will be matched.
        /// </remarks>
        /// <param name="marked">The value to match.</param>
        /// <returns>A new <see cref="ElementQuery"/> based on the first element that matches <paramref name="marked"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="identifier"/> is null.</exception>
        public ElementQuery Marked(string identifier)
        {
            ArgumentNullException.ThrowIfNull(identifier);

            var queryResult = Element.FindInternal(e => e.Marked(identifier))
                .FirstOrDefault();
            // TODO: Handle no results
                // ElementNotFoundException?
            // TODO: Does QueryInternal need to be recursive? Yes, as it needs to search the entire view hierarchy by default.
                // Should it match the first fround result? Yes.
                // Should we only ever return a single result? Yes.

            return new ElementQuery(queryResult);
        }
    }
}
