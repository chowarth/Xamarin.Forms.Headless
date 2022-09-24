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
        /// Queries the current view hierarchy for an element that matches the supplied <paramref name="marked"/> value.
        /// Elements will be matched against <c>AutomationId</c> first, then depending on the element, <c>Title, Text, FormattedText, Placeholder</c>.
        /// </summary>
        /// <remarks>
        /// Only visible elements will be matched.
        /// </remarks>
        /// <param name="marked">The value to match</param>
        public ElementQuery Marked(string identifier)
        {
            ArgumentNullException.ThrowIfNull(identifier);

            var queryResult = Element.QueryInternal(e => e.Marked(identifier))
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
