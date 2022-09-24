using Xamarin.Forms;

namespace XF.Headless.Queries
{
    public abstract class BaseElementQuery
    {
        /// <summary>
        /// The Xamarin.Forms element that the query is run against.
        /// </summary>
        /// <remarks>
        /// Internal so that it can't be accessed outside of this assembly.
        /// </remarks>
        internal Element Element { get; }

        internal BaseElementQuery(Element element)
        {
            Element = element;
        }
    }
}
