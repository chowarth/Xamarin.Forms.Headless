using Xamarin.Forms;

namespace XF.Headless.Extensions
{
    internal static class PageExtensions
    {
        public static Page GetCurrentPage(this Page page)
        {
            if (page is FlyoutPage fp)
            {
                if (fp.IsPresented)
                    return GetCurrentPage(fp.Flyout);
                else
                    return GetCurrentPage(fp.Detail);
            }

            // TabbedPage & NavigationPage
            if (page is IPageContainer<Page> pc)
                return GetCurrentPage(pc.CurrentPage);

            return page;
        }
    }
}
