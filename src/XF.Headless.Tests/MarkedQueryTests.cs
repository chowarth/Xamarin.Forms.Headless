using System;
using Xamarin.Forms;
using XF.Headless.Queries;
using Xunit;

namespace XF.Headless.Tests
{
    public class MarkedQueryTests
    {
        [Fact]
        public void Marked_NullIdentifier_ThrowsArgumentNullException()
        {
            // Arrange
            var query = new MarkedQuery(new Label());
            var markedIdentifier = default(string);

            // Act
            Func<ElementQuery> markedFunc = () => query.Marked(markedIdentifier);

            // Assert
            Assert.Throws<ArgumentNullException>(markedFunc);
        }

        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        public void Marked_EmptyOrWhitespaceIdentifier_ThrowsArgumentException(string markedIdentifier)
        {
            // Arrange
            var query = new MarkedQuery(new Label());

            // Act
            Func<ElementQuery> markedFunc = () => query.Marked(markedIdentifier);

            // Assert
            Assert.Throws<ArgumentException>(markedFunc);
        }

        [Theory]
        [InlineData("TestAutomationId", typeof(Label))]
        [InlineData("TestButtonAutomationId", typeof(Button))]
        public void Query_ByMarked_ReturnsExpectedElementType(string markedIdentifier, Type expectedType)
        {
            // Arrange
            var app = HeadlessAppBuilder.ForApp(() => new SampleApp.App())
                .Build();
            app.Tap("Query Page");

            // Act
            var button = app.Query(x => x.Marked(markedIdentifier));

            // Assert
            Assert.NotNull(button);
            Assert.IsType(expectedType, button);
        }
    }
}
