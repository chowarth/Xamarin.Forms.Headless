using System;
using Xamarin.Forms;
using XF.Headless.SampleApp.Pages;
using Xunit;

namespace XF.Headless.Tests
{
    public class ElementQueryTests
    {
        [Theory]
        [InlineData("TestButtonAutomationId", typeof(Button))]
        public void Query_WithMarkedIdentifier_ReturnsExpectedElementType(string markedIdentifier, Type expectedType)
        {
            // Arrage
            var app = HeadlessAppBuilder.ForApp(() => new SampleApp.App())
                .Build();

            // Assert
            var button = app.Query(x => x.Marked(markedIdentifier));

            // Act
            Assert.NotNull(button);
            Assert.IsType(expectedType, button);
        }

        [Theory]
        [InlineData(0, typeof(StackLayout))]
        [InlineData(1, typeof(MainPage))]
        //[InlineData(4, typeof(MainPage))] // Results in a null parent
        public void Query_WithParentByIndex_ReturnsExpectedElementParent(int parentIndex, Type expectedType)
        {
            // Arrange
            var app = HeadlessAppBuilder.ForApp(() => new SampleApp.App())
                .Build();

            // Act
            var parent = app.Query(x => x.Marked("TestButtonAutomationId")
                                         .Parent(parentIndex));

            // Assert
            Assert.NotNull(parent);
            Assert.IsType(expectedType, parent);
        }
    }
}
