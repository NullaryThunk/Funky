#pragma warning disable CS8509
using FsCheck;
using FsCheck.FSharp;
using NullaryThunk.Funky.Core.Options;
using static FsCheck.Fluent.Prop;
using static NullaryThunk.Funky.Core.Tests.Options.OptionGenerators;

namespace NullaryThunk.Funky.Core.Tests.Options;

[TestFixture]
public class OptionTests
{
    [Test]
    public static void ArbitraryOptionIntTest() => ForAll(OptionOfInt(),
    pair => pair switch
    {
        (_ ,Nothing<int>) => true,
        (var expected, Something<int>(var value)) when value == expected => true
    }).QuickCheckThrowOnFailure();

    [Test]
    public static void CastingIntToSomethingHasSameValueAsOriginalInt()
        => ForAll(Arb.From(Integers), value =>
        value == ((Something<int>)value).Value).QuickCheckThrowOnFailure();
    
    [Test]
    public static void SomethingsNeverHasAnyNones() => ForAll(OptionsOfInt(), options => 
    options.Somethings() switch
    {
        var nones when nones.Any(n => n is Nothing<int>) => false,
        _ => true
    }).QuickCheckThrowOnFailure();
}