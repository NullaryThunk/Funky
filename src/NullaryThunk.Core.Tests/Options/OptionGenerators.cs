using FsCheck;
using FsCheck.Fluent;
using NullaryThunk.Core.Options;

namespace NullaryThunk.Core.Tests.Options;

public static class OptionGenerators
{
    public static Arbitrary<(int Value,Option<int> Option)> OptionOfInt()
    {
        var generator = Gen
            .Choose(int.MinValue, int.MaxValue)
            .Select((int,Option<int>) (value) => (value,value.ToSomething()))
            .Or(Gen.Constant<(int, Option<int>)>((0,O.Nothing<int>())));
        return Arb.From(generator);
    }

    public static Arbitrary<Option<int>[]> OptionsOfInt() =>
        Arb.From(
            Gen.Choose(int.MinValue, int.MaxValue)
                .Select(Option<int> (value) => value.ToSomething())
                .Or(Gen.Constant<Option<int>>(O.Nothing<int>())).ArrayOf());
}