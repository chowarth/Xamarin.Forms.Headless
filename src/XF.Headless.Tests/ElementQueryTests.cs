
using System;
using Xamarin.Forms;
using XF.Headless.SampleApp.Pages;
using Xunit;

namespace XF.Headless.Tests
{
    public class ElementQueryTests
    {
        [Theory]
        [InlineData(0, typeof(StackLayout))]
        [InlineData(1, typeof(QueryPage))]
        //[InlineData(2, typeof(MainPage))] // Results in 'NavigationPage' type parent
        //[InlineData(3, typeof(MainPage))] // Results in 'Application' type parent
        //[InlineData(4, typeof(MainPage))] // Results in 'null' parent
        public void Query_ByParent_ReturnsExpectedElementParentType(int parentIndex, Type expectedType)
        {
            // Arrange
            var app = HeadlessAppBuilder.ForApp(() => new SampleApp.App())
                .Build();
            app.Tap("Query Page");

            // Act
            var parent = app.Query(x => x.Marked("TestAutomationId")
                                         .Parent(parentIndex));

            // Assert
            Assert.NotNull(parent);
            Assert.IsType(expectedType, parent);
        }
    }
}
