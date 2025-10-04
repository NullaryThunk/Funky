using AwesomeAssertions;

namespace NullaryThunk.Core.Tests.Options;

[TestFixture]
public class OptionTests
{
    [Test]
    public void PassesAlways() => 1.Should().Be(1);
}