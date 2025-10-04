#pragma warning disable CS8509
using FsCheck;
using FsCheck.Fluent;
using NullaryThunk.Core.Options;
using static NullaryThunk.Core.Tests.Options.OptionGenerators;

namespace NullaryThunk.Core.Tests.Options;

[TestFixture]
public class OptionTests
{
    [Test]
    public static void ArbitraryOptionIntTest() => Prop.ForAll(OptionsOfInt(), option =>
    {
        return option switch
        {
            (_ ,Nothing<int>) => true,
            (var expected, Something<int>(var value)) when value == expected => true
        };
    }).QuickCheckThrowOnFailure();
}