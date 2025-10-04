namespace NullaryThunk.Funky.Core.Options;

public interface Option<out T> {}

public interface Nothing;

public interface Something;

public interface ISomething<out T> : Option<T>,  Something { T Value { get; }} 
public record Something<T>(T Value) : ISomething<T>
{
    public static implicit operator Something<T>(T value) => new(value);
}

public record Nothing<T> : Option<T>, Nothing;

public static class O
{
    public static Something<T> ToSomething<T>(this T value) => new(value);
    public static Nothing<T> Nothing<T>() => new();

    public static IEnumerable<T> Somethings<T>(this IEnumerable<Option<T>> options) =>
        options.Where(o => o is Something<T>).Cast<Something<T>>().Select(s => s.Value);
}