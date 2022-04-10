using System;
using Xunit;

namespace XF.Headless.Tests
{
    public class TapTests
    {
        [Fact]
        public void Tap_ElementCommandIsNull_ThrowsInvalidOperationException()
        {
            var app = HeadlessAppBuilder.Create()
                .ForApplication(() => new SampleApp.App())
                .Build();
            string marked = "TestButtonAutomationId";

            Action action = () => app.Tap(marked);

            Assert.Throws<InvalidOperationException>(action);
        }
    }
}
