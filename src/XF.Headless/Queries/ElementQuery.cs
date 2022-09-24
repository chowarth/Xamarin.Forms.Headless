using System;
using System.Linq;
using Xamarin.Forms;
using XF.Headless.Extensions;

namespace XF.Headless.Queries
{
    public sealed class ElementQuery : IMarkedQuery
    {
        /*
        - ElementQuery: Used to find elements based on "marked"
            - Parent() returns the parent element
                - Optional index parameter (0 by default)
            - Sibling() returns the sibling for current element
                - Optional index parameter (0 by default)
            - Child() returns a child of the current element
                - Optional index parameter (0 by default)
                - InvalidOperationException if an element can't have any children
            - Marked(sting marked) triggers the search for the element based on its parameter
                - marked parameter CANNOT be null
                    - Best way to do this: Enable nullable or [NotNull]?
                - How best to handle Marked being called at the end of a method chain?
                    - Would is simply be checking the element that the other methods (Parent, Sibling, & Child) filtered to see if it matches?
        */
        public Element Element { get; }

        internal ElementQuery(Element element)
        {
            Element = element;
        }

        /// <summary>
        /// Queries the current view hierarchy for an element that matches the supplied <paramref name="marked"/> value.
        /// Elements will be matched against <c>AutomationId</c> first, then depending on the element, <c>Title, Text, FormattedText, Placeholder</c>.
        /// </summary>
        /// <remarks>
        /// Only visible elements will be returned.
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

        public ElementQuery Parent(int index = 0)
        {
            var current = Element.Parent;

            // TODO:
            // What to do if index take us to a parent outside of this page?
            // What if current.Parent is null?
            // IndexOutOfRangeException?
            // e.g. If 0 would be StackLayout, 1 would be the Page itself, 2 would be the NavigationPage/TabbedPage/App
            while (index > 0)
            {
                current = current.Parent;
                index--;
            }

            return new ElementQuery(current);
        }
    }
}
