using FsCheck;
using FsCheck.Fluent;
using NullaryThunk.Core.Options;

namespace NullaryThunk.Core.Tests.Options;

public static class OptionGenerators
{
    public static Gen<int> Integers => Gen.Choose(int.MinValue, int.MaxValue);
    public static Arbitrary<(int Value,Option<int> Option)> OptionOfInt()
    {
        var generator = Integers
            .Select((int,Option<int>) (value) => (value,value.ToSomething()))
            .Or(Gen.Constant<(int, Option<int>)>((0,O.Nothing<int>())));
        return Arb.From(generator);
    }

    public static Arbitrary<Option<int>[]> OptionsOfInt() =>
        Arb.From(
            Integers
                .Select(Option<int> (value) => value.ToSomething())
                .Or(Gen.Constant<Option<int>>(O.Nothing<int>())).ArrayOf());
}