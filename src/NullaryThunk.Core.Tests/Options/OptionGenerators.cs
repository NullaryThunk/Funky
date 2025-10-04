using FsCheck;
using FsCheck.Fluent;
using NullaryThunk.Core.Options;

namespace NullaryThunk.Core.Tests.Options;

public static class OptionGenerators
{
    public static Arbitrary<(int Value,Option<int> Option)> OptionsOfInt()
    {
        var generator = Gen
            .Choose(int.MinValue, int.MaxValue)
            .Select((int,Option<int>) (value) => (value,value.ToSomething()))
            .Or(Gen.Constant<(int, Option<int>)>((0,O.Nothing<int>())));
        return Arb.From(generator);
    }
}