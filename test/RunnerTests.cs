using System;
using System.Text;
using Xunit;

namespace TAP.Core.Tests
{
    public class RunnerTests
    {
        [Fact]
        public void AssertingTrueFalseToOKReportsMessagesCorrectly()
        {
            var oldOut = Console.Out;
            StringBuilder builder = new StringBuilder();
            Console.SetOut(new TestTextWriter(builder));

            var okMessage = "hello!";
            var condition = true;

            var result = TAP.Ok(condition, okMessage);

            Assert.Equal(condition, result);
            Assert.Equal("ok 1 - " + okMessage, builder.ToString());

            builder.Clear();

            condition = false;

            result = TAP.Ok(condition, okMessage);

            Assert.Equal(condition, result);
            Assert.StartsWith("not ok 2 - " + okMessage, builder.ToString());

            Console.SetOut(oldOut);
        }
    }
}
