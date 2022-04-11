using Xamarin.Forms;

namespace XF.Headless.SampleApp.Pages
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            Title = "Main Page";
            Content = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    new Button() { AutomationId = "TestButtonAutomationId" },
                    new Button()
                    {
                        Text = "Query Page",
                        Command = new Command(() => Navigation.PushAsync(new QueryPage()))
                    }
                }
            };
        }
    }
}