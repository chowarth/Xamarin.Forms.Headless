using System;
using Xamarin.Forms;
using XF.Headless.Helpers;

namespace XF.Headless
{
    public sealed class HeadlessAppBuilder : IApplicationSetup, IBuild
    {
        private Func<Application> _appProvider;

        private HeadlessAppBuilder() { }

        /// <summary>
        /// Creates a new instance of <see cref="HeadlessAppBuilder"/>
        /// </summary>
        /// <returns></returns>
        public static IApplicationSetup Create()
        {
            return new HeadlessAppBuilder();
        }

        /// <inheritdoc/>
        public IBuild ForApplication(Func<Application> appProvider)
        {
            ArgumentNullException.ThrowIfNull(appProvider);

            _appProvider = appProvider;
            return this;
        }

        /// <inheritdoc/>
        public IHeadlessApp Build()
        {
            return new HeadlessApp(_appProvider);
        }
    }
}
