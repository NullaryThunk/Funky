using AwesomeAssertions;
using NullaryThunk.Funky.Core.Options;
using static System.Int32;
using static NullaryThunk.Funky.Core.Options.O;

namespace NullaryThunk.Funky.Core.Tests.Options;
[TestFixture]
public class SomethingOrTests
{
    [Test]
    public static void Something_Yields_Value_Of_Something([Random(MinValue, MaxValue, 5 )]int value, [Random(MinValue, MaxValue, 5)]int ifNone) 
        => value.ToSomething().SomethingOr(ifNone).Should().Be(value);
    
    [Test]
    public static void Nothing_Yields_Value_Of_IfNone([Random(MinValue, MaxValue, 5 )]int value, [Random(MinValue, MaxValue, 5)]int ifNone) 
        => Nothing<int>().SomethingOr(ifNone).Should().Be(ifNone);
    
    [Test]
    public static void With_Something_Nullary_Yields_Same_As_Without([Random(MinValue, MaxValue, 5 )]int value, [Random(MinValue, MaxValue, 5)]int ifNone) 
        => value.ToSomething().SomethingOr(x => x, ifNone).Should().Be(value.ToSomething().SomethingOr(ifNone));
    
    [Test]
    public static void With_Nothing_Nullary_Yields_Same_As_Without([Random(MinValue, MaxValue, 5 )]int value, [Random(MinValue, MaxValue, 5)]int ifNone) 
        => Nothing<int>().SomethingOr(x => x, ifNone).Should().Be(Nothing<int>().SomethingOr(ifNone));
}