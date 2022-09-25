using System;
using Xunit;

namespace XF.Headless.Tests
{
    public class TapTests
    {
        // TODO: public void Tap_ElementIsNotFound_ThrowsInvalidOperationException()
        // TODO: public void Tap_ElementIsNotTappable_ThrowsInvalidOperationException()

        [Fact]
        public void Tap_ElementCommandIsNull_ThrowsInvalidOperationException()
        {
            var app = HeadlessAppBuilder.ForApp(() => new SampleApp.App())
                .Build();
            string marked = "No command";

            Action action = () => app.Tap(marked);

            Assert.Throws<InvalidOperationException>(action);
        }
    }
}
