using Xamarin.Forms;
using Xunit;

namespace XF.Headless.Tests
{
    public class QueryTests
    {
        [Fact]
        public void Query_ByAutomationId_ReturnsLabel()
        {
            // Arrange
            var app = HeadlessAppBuilder.ForApp(() => new SampleApp.App())
                .Build();
            app.Tap("Query Page");

            // Act
            Element result = app.Query("TestAutomationId");

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Label>(result);
            Assert.Equal("Start developing now", (result as Label)?.Text);
        }

        [Fact]
        public void Query_ByText_ReturnsLabel()
        {
            // Arrange
            var app = HeadlessAppBuilder.ForApp(() => new SampleApp.App())
                .Build();
            app.Tap("Query Page");

            // Act
            Element result = app.Query("Welcome to Xamarin.Forms!");

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Label>(result);
        }

        [Fact]
        public void Query_ParentIsVisibleFalse_ReturnsNoResults()
        {
            // Arrange
            var app = HeadlessAppBuilder.ForApp(() => new SampleApp.App())
                .Build();
            app.Tap("Query Page");

            // Act
            Element result = app.Query("This label should not be found!");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Query_ByFormattedString_ReturnsLabel()
        {
            // Arrange
            var app = HeadlessAppBuilder.ForApp(() => new SampleApp.App())
                .Build();
            app.Tap("Query Page");

            // Act
            Element result = app.Query("Learn more at https://aka.ms/xamarin-quickstart");

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Label>(result);
        }

        [Fact]
        public void Query_ElementInTitleView_ReturnsLabel()
        {
            // Arrange
            var app = HeadlessAppBuilder.ForApp(() => new SampleApp.App())
                .Build();
            app.Tap("Query Page");

            // Act
            Element result = app.Query("TitleViewLabelId");

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Label>(result);
            Assert.Equal("TitleViewLabel", (result as Label)?.Text);
        }
    }
}
