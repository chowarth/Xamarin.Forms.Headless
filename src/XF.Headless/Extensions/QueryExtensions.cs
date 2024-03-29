﻿using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XF.Headless.Extensions
{
    internal static class QueryExtensions
    {
        internal static IEnumerable<Element> Empty = Enumerable.Empty<Element>();

        internal static List<Element> QueryInternal(this Element element, Predicate<Element> predicate)
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
                            results.AddRange(titleView.QueryInternal(predicate));
                    }

                    results.AddRange(cp.Content?.QueryInternal(predicate) ?? Empty);
                    break;

                // StackLayout, Grid, FlexLayout, AbsoluteLayout
                case Layout<View> lv:
                    results.AddRange(lv.Children.SelectMany(c => c.QueryInternal(predicate)));
                    break;

                // Frame, ContentView
                case ContentView cv:
                    results.AddRange(cv.Content?.QueryInternal(predicate) ?? Empty);
                    break;

                case ScrollView sv:
                    results.AddRange(sv.Content?.QueryInternal(predicate) ?? Empty);
                    break;

                case ViewCell vc:
                    results.AddRange(vc.View?.QueryInternal(predicate) ?? Empty);
                    break;

                default:
                    break;
            }

            return results;
        }
    }
}
