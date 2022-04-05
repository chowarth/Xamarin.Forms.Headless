using Xamarin.Forms;

namespace XF.Headless.Extensions
{
    internal static class ElementExtensions
    {
        internal static bool Marked(this Element element, string marked)
        {
            // Don't match if the element isn't visible
            if (element is VisualElement ve && !ve.IsVisible)
                return false;

            if (element.AutomationId == marked)
                return true;

            return element switch
            {
                Button b => b.Text == marked,
                Label l => l.Text == marked || l.FormattedText?.ToString() == marked,
                Entry e => e.Text == marked || e.Placeholder == marked,
                Editor ed => ed.Text == marked || ed.Placeholder == marked,
                Picker p => p.Title == marked || p.SelectedItem?.ToString() == marked,
                SearchBar s => s.Text == marked || s.Placeholder == marked,

                // default:
                _ => false
            };
        }
    }
}
