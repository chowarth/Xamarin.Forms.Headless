using System.ComponentModel;
using Xamarin.Forms;

namespace XF.Headless.Queries
{
    public interface IElementQuery
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        Element Element { get; }
    }
}
