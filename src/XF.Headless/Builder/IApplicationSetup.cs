using System;
using Xamarin.Forms;

namespace XF.Headless
{
    public interface IApplicationSetup
    {
        /// <summary>
        /// Sets the Xamarin.Forms application to be used in a headless state
        /// </summary>
        /// <param name="appProvider">Delegate to provide an instance of a Xamarin.Forms application</param>
        /// <returns></returns>
        public IBuild ForApplication(Func<Application> appProvider);
    }
}
