using System.Collections.Generic;
using Xamarin.Forms;
using Xunit;

namespace XF.Headless.Tests
{
    public class QueryTests
    {
        [Fact]
        public void Query_ByAutomationId_ReturnsMultipleResults()
        {
            // Arrange
            var app = HeadlessAppBuilder.Create()
                .ForApplication(() => new SampleApp.App())
                .Build();
            app.Tap("Query Page");

            // Act
            IReadOnlyList<Element> results = app.Query("TestAutomationId");

            // Assert
            Assert.Equal(2, results.Count);
        }

        [Fact]
        public void Query_ByText_ReturnsSingleResult()
        {
            // Arrange
            var app = HeadlessAppBuilder.Create()
                .ForApplication(() => new SampleApp.App())
                .Build();
            app.Tap("Query Page");

            // Act
            IReadOnlyList<Element> results = app.Query("Welcome to Xamarin.Forms!");

            // Assert
            Assert.Equal(1, results.Count);
        }

        [Fact]
        public void Query_ParentIsVisibleFalse_ReturnsNoResults()
        {
            // Arrange
            var app = HeadlessAppBuilder.Create()
                .ForApplication(() => new SampleApp.App())
                .Build();
            app.Tap("Query Page");

            // Act
            IReadOnlyList<Element> results = app.Query("This label should not be found!");

            // Assert
            Assert.Empty(results);
        }

        [Fact]
        public void Query_ByFormattedString_ReturnsSingleResult()
        {
            // Arrange
            var app = HeadlessAppBuilder.Create()
                .ForApplication(() => new SampleApp.App())
                .Build();
            app.Tap("Query Page");

            // Act
            IReadOnlyList<Element> results = app.Query("Learn more at https://aka.ms/xamarin-quickstart");

            // Assert
            Assert.Equal(1, results.Count);
        }

        [Fact]
        public void Query_ElementInTitleView_ReturnsSingleResult()
        {
            // Arrange
            var app = HeadlessAppBuilder.Create()
                .ForApplication(() => new SampleApp.App())
                .Build();
            app.Tap("Query Page");

            // Act
            IReadOnlyList<Element> results = app.Query("TitleViewLabel");

            // Assert
            Assert.Equal(1, results.Count);
        }
    }
}
