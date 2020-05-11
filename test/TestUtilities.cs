using System.IO;
using System.Text;

namespace TAP.Core.Tests
{
    internal class TestTextWriter : TextWriter
    {
        private readonly StringBuilder _builder;
        public TestTextWriter(StringBuilder builder) => _builder = builder;

        public override Encoding Encoding => Encoding.UTF8;

        public override void Write(string message) => _builder.Append(message);

        public override void WriteLine(string message) => _builder.Append(message);

        public override void Write(string format, params object[] args) =>
            _builder.AppendFormat(string.Format(format, args));

        public override void WriteLine(string format, params object[] args) =>
            _builder.AppendFormat(format, args);
    }
}
