using Xamarin.Forms;

namespace XF.Headless.Queries
{
    public sealed class ElementQuery : BaseElementQuery
    {
        /*
        - ElementQuery: Used to find elements based on "marked"
            - Parent() returns the parent element
                - Optional index parameter (0 by default)
                - IndexOutOfRangeException if index is out of range
            - Sibling() returns the sibling for current element
                - Optional index parameter (0 by default)
                - IndexOutOfRangeException if index is out of range
            - Child() returns a child of the current element
                - Optional index parameter (0 by default)
                - InvalidOperationException if an element can't have any children
                - IndexOutOfRangeException if index is out of range
            - Marked(sting marked) triggers the search for the element based on its parameter
                - marked parameter CANNOT be null
                    - Best way to do this: Enable nullable or [NotNull]?
                - How best to handle Marked being called at the end of a method chain?
                    - Would is simply be checking the element that the other methods (Parent, Sibling, & Child) filtered to see if it matches?
                    - Would this even be needed based on the result of the other methods?
        */

        internal ElementQuery(Element element)
            : base(element)
        {
        }

        public ElementQuery Parent(int index = 0)
        {
            var current = Element.Parent;

            // TODO:
            // What to do if index take us to a parent outside of this page?
            // What if current.Parent is null?
                // IndexOutOfRangeException or InvalidOperationException?
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
