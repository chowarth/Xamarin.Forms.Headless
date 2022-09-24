using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XF.Headless.Extensions
{
    internal static class QueryExtensions
    {
        internal static IEnumerable<Element> Empty = Enumerable.Empty<Element>();

        /// <summary>
        /// Finds an element that matches the provided <paramref name="predicate"/>.
        /// </summary>
        /// <param name="element">The root element.</param>
        /// <param name="predicate">The predicate to match the element against.</param>
        /// <returns>A list of elements that match the provided <paramref name="predicate"/>.</returns>
        internal static List<Element> FindInternal(this Element element, Predicate<Element> predicate)
        {
            List<Element> results = new List<Element>();

            // Don't need do anything if the element isn't visible
            if (element is VisualElement ve && !ve.IsVisible)
                return results;

            if (predicate.Invoke(element))
                results.Add(element);

            switch (element)
            {
                case ContentPage cp:
                    // Query NavigationPage.TitleView if there is one
                    if (cp.Parent is NavigationPage)
                    {
                        var titleView = NavigationPage.GetTitleView(element);
                        if (titleView is not null)
                            results.AddRange(titleView.FindInternal(predicate));
                    }

                    results.AddRange(cp.Content?.FindInternal(predicate) ?? Empty);
                    break;

                // StackLayout, Grid, FlexLayout, AbsoluteLayout
                case Layout<View> lv:
                    results.AddRange(lv.Children.SelectMany(c => c.FindInternal(predicate)));
                    break;

                // Frame, ContentView
                case ContentView cv:
                    results.AddRange(cv.Content?.FindInternal(predicate) ?? Empty);
                    break;

                case ScrollView sv:
                    results.AddRange(sv.Content?.FindInternal(predicate) ?? Empty);
                    break;

                case ViewCell vc:
                    results.AddRange(vc.View?.FindInternal(predicate) ?? Empty);
                    break;

                default:
                    break;
            }

            return results;
        }
    }
}
