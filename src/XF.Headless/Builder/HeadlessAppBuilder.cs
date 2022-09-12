using System;
using Xamarin.Forms;

namespace XF.Headless
{
    public sealed class HeadlessAppBuilder : IBuild
    {
        private readonly Func<Application> _appProvider;

        private HeadlessAppBuilder(Func<Application> appProvider)
        {
            _appProvider = appProvider;
        }

        /// <summary>
        /// Creates a new instance of <see cref="HeadlessAppBuilder"/> for the provided application
        /// </summary>
        /// <param name="appProvider">Delegate to provide an instance of a Xamarin.Forms application</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="appProvider"/> is <see langword="null"/></exception>
        public static IBuild ForApp(Func<Application> appProvider)
        {
            ArgumentNullException.ThrowIfNull(appProvider);

            return new HeadlessAppBuilder(appProvider);
        }

        /// <inheritdoc/>
        public IHeadlessApp Build()
        {
            return new HeadlessApp(_appProvider);
        }
    }
}
