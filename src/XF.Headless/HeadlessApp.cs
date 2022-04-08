using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using XF.Headless.Extensions;

namespace XF.Headless
{
    internal sealed class HeadlessApp : IHeadlessApp
    {
        private readonly Application _app;

        internal HeadlessApp(Func<Application> appProvider)
        {
            MockForms.Init();

            _app = appProvider.Invoke();

            // Hook into Xamarin.Forms messages for AlertArguments & ActionSheetArguments
        }

        /// <inheritdoc/>
        public void OnStart()
        {
            _app.Invoke("OnStart");
        }

        /// <inheritdoc/>
        public void OnSleep()
        {
            _app.Invoke("OnSleep");
        }

        /// <inheritdoc/>
        public void OnResume()
        {
            _app.Invoke("OnResume");
        }

        /// <inheritdoc/>
        public IReadOnlyList<Element> Query(string marked)
        {
            var top = _app.MainPage.Navigation.ModalStack.LastOrDefault() ?? _app.MainPage;

            return GetCurrentPage(top).QueryInternal(e => e.Marked(marked));
        }

        private Page GetCurrentPage(Page page)
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
