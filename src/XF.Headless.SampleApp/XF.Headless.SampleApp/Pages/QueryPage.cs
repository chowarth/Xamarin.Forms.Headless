using Xamarin.CommunityToolkit.Markup;
using Xamarin.Forms;

namespace XF.Headless.SampleApp.Pages
{
    public class QueryPage : ContentPage
    {
        public QueryPage()
        {
            NavigationPage.SetTitleView(this, new StackLayout
            {
                Children = 
                {
                    new Label
                    {
                        AutomationId = "TitleViewLabelId",
                        Text = "TitleViewLabel",
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center
                    }
                }
            });

            Title = "Query Page";
            Content = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    new Frame()
                    {
                        Content = new Label { Text = "Welcome to Xamarin.Forms!" }
                    },
                    new Frame()
                    {
                        IsVisible = false,
                        Content = new Label { Text = "This label should not be found!" }
                    },
                    new Button()
                    {
                        AutomationId = "TestButtonAutomationId"
                    },
                    new Label
                    {
                        AutomationId = "TestAutomationId",
                        Text = "Start developing now"
                    },
                    new Label
                    {
                        AutomationId = "TestAutomationId",
                        Text = "Make changes to your XAML file and save to see your UI update in the running app with XAML Hot Reload. Give it a try!"
                    },
                    new Label
                    {
                        AutomationId = "TestAutomationId",
                        Text = "This label is not visible",
                        IsVisible = false
                    },
                    new Label()
                        .FormattedText( new Span { Text = "Learn more at " },
                                        new Span { Text = "https://aka.ms/xamarin-quickstart", FontAttributes = FontAttributes.Bold })
                }
            };
        }
    }
}
