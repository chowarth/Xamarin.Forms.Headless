using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
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
            ArgumentNullException.ThrowIfNull(marked);

            var top = _app.MainPage.Navigation.ModalStack.LastOrDefault() ?? _app.MainPage;
            return GetCurrentPage(top).QueryInternal(e => e.Marked(marked));
        }

        /// <inheritdoc/>
        public void Tap(string marked)
        {
            // TODO: Alert dialogs/pickers etc
            // TODO: If nothing is found, throw exception?
            // TODO: How to handle multiple elements with the same ID e.g. in a list "cell"?

            var element = Query(marked).FirstOrDefault();

            if (InvokeTapGestureRecognisers(element))
                return;

            switch (element)
            {
                case Button b:
                    InvokeCommand(marked, b.Command, b.CommandParameter);
                    break;

                case ImageButton ib:
                    InvokeCommand(marked, ib.Command, ib.CommandParameter);
                    break;

                default:
                    throw new NotSupportedException($"Element marked '{marked}' is not tappable; {element.GetType().Name} is not supported.");
            }
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

        private bool InvokeTapGestureRecognisers(Element element)
        {
            bool invoked = false;

            if (element is View view)
            {
                var tgrs = view.GestureRecognizers.OfType<TapGestureRecognizer>();
                if (tgrs.Any())
                {
                    foreach (var tgr in tgrs)
                        tgr.SendTapped(view);

                    invoked = true;
                }
            }

            return invoked;
        }

        private void InvokeCommand(string marked, ICommand command, object commandParameter)
        {
            if (command == null)
                throw new InvalidOperationException($"Element marked '{marked}' is not tappable; '{nameof(command)}' is null.");

            if (command.CanExecute(commandParameter))
                command.Execute(commandParameter);
        }
    }
}
