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
            var app = HeadlessAppBuilder.Create()
                .ForApplication(() => new SampleApp.App())
                .Build();

            IReadOnlyList<Element> results = app.Query("TestAutomationId");

            Assert.Equal(2, results.Count);
        }

        [Fact]
        public void Query_ByText_ReturnsSingleResult()
        {
            var app = HeadlessAppBuilder.Create()
                .ForApplication(() => new SampleApp.App())
                .Build();

            IReadOnlyList<Element> results = app.Query("Welcome to Xamarin.Forms!");

            Assert.Equal(1, results.Count);
        }

        [Fact]
        public void Query_ParentIsVisibleFalse_ReturnsNoResults()
        {
            var app = HeadlessAppBuilder.Create()
                .ForApplication(() => new SampleApp.App())
                .Build();

            IReadOnlyList<Element> results = app.Query("This label should not be found!");

            Assert.Empty(results);
        }

        [Fact]
        public void Query_ByFormattedString_ReturnsSingleResult()
        {
            var app = HeadlessAppBuilder.Create()
                .ForApplication(() => new SampleApp.App())
                .Build();

            IReadOnlyList<Element> results = app.Query("Learn more at https://aka.ms/xamarin-quickstart");

            Assert.Equal(1, results.Count);
        }

        [Fact]
        public void Query_ElementInTitleView_ReturnsSingleResult()
        {
            var app = HeadlessAppBuilder.Create()
                .ForApplication(() => new SampleApp.App())
                .Build();

            IReadOnlyList<Element> results = app.Query("TitleViewLabel");

            Assert.Equal(1, results.Count);
        }
    }
}
