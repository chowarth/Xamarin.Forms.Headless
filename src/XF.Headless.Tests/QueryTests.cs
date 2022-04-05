using System.Collections.Generic;
using Xamarin.Forms;
using Xunit;

namespace XF.Headless.Tests
{
    public class QueryTests
    {
        [Fact]
        public void QueryElementByAutomationId()
        {
            var app = HeadlessAppBuilder.Create()
                .ForApplication(() => new SampleApp.App())
                .Build();

            IReadOnlyList<Element> results = app.Query("TestAutomationId");

            Assert.Equal(2, results.Count);
        }

        [Fact]
        public void QueryElementByText()
        {
            var app = HeadlessAppBuilder.Create()
                .ForApplication(() => new SampleApp.App())
                .Build();

            IReadOnlyList<Element> results = app.Query("Welcome to Xamarin.Forms!");

            Assert.Equal(1, results.Count);
        }

        [Fact]
        public void QueryElementByFormattedString()
        {
            var app = HeadlessAppBuilder.Create()
                .ForApplication(() => new SampleApp.App())
                .Build();

            IReadOnlyList<Element> results = app.Query("Learn more at https://aka.ms/xamarin-quickstart");

            Assert.Equal(1, results.Count);
        }

        [Fact]
        public void QueryTitleViewByText()
        {
            var app = HeadlessAppBuilder.Create()
                .ForApplication(() => new SampleApp.App())
                .Build();

            IReadOnlyList<Element> results = app.Query("TitleViewLabel");

            Assert.Equal(1, results.Count);
        }
    }
}
