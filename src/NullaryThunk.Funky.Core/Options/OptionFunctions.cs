namespace NullaryThunk.Funky.Core.Options;

public static class OptionFunctions
{
    public static T SomethingOr<T>(this Option<T> opt, T ifNone) =>
        opt is Something<T>(var value) ? value : ifNone;

    public static R SomethingOr<T, R>(this Option<T> opt, Func<T, R> mapper, R ifNone) =>
        opt is Something<T>(var value) ? mapper(value) : ifNone;
}