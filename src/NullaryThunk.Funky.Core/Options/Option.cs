namespace NullaryThunk.Funky.Core.Options;

/// <summary>
/// Represents the possibility of a <typeparamref name="T"/>.
/// An <see cref="Option{T}"/> can be either <see cref="Something{T}"/> or <see cref="Nothing{T}"/>.
/// If it is a <see cref="Something{T}"/> then it contains a value of <typeparam name="T"></typeparam>.
/// Use pattern matching to match on an <see cref="Option{T}"/>
/// </summary>
/// <typeparam name="T">The underlying value type.</typeparam>
public interface Option<out T> {}

/// <summary>
/// An object with no meaningful value. Represents the absence of a value.
/// </summary>
public interface Nothing;

/// <summary>
/// An <see cref="Option{T}"/> that has no meaningful value.
/// </summary>
public interface Something;

/// <summary>
/// An <see cref="Option{T}"/> that has a meaningful value.
/// </summary>
/// <typeparam name="T">The type of the meaningful value contained within.</typeparam>
public interface ISomething<out T> : Option<T>, Something { T Value { get; }} 

/// <summary>
/// An <see cref="Option{T}"/> that has a meaningful value.
/// </summary>
/// <param name="Value">The meaningful value.</param>
/// <typeparam name="T">The type of the meaningful value.</typeparam>
public record Something<T>(T Value) : ISomething<T>
{
    /// <summary>
    /// Implicitly converts a value of type <typeparamref name="T"/> into a <see cref="Something{T}"/>.
    /// </summary>
    /// <param name="value">The value to wrap.</param>
    /// <returns>A <see cref="Something{T}"/> containing the provided value.</returns>
    public static implicit operator Something<T>(T value) => new(value);
}

/// <summary>
/// An <see cref="Option{T}"/> that has no meaningful value.
/// </summary>
/// <typeparam name="T">The type of the meaningful value.</typeparam>
public record Nothing<T> : Option<T>, Nothing;

/// <summary>
/// Provides functions for working with <see cref="Option{T}" values./>
/// </summary>
public static class O
{
    /// <summary>
    /// Lifts a meaningful value into a <see cref="Something{T}"/>.
    /// </summary>
    /// <param name="value">The meaningful value.</param>
    /// <typeparam name="T">The type of the meaningful value.</typeparam>
    /// <returns>A <see cref="Something{T}"/> containing the meaningful value.</returns>
    public static Something<T> ToSomething<T>(this T value) => new(value);
    
    /// <summary>
    /// Creates a <see cref="Nothing{T}"/>.
    /// </summary>
    /// <typeparam name="T">The underlying type of the meaningful value.</typeparam>
    /// <returns>An instance of <see cref="Nothing{T}"/></returns>
    public static Nothing<T> Nothing<T>() => new();

    /// <summary>
    /// Extracts the underlying values from a sequence of <see cref="Option{T}"/> items,
    /// returning only the values wrapped in <see cref="Something{T}" />
    /// </summary>
    /// <param name="options">A sequence of optional values</param>
    /// <typeparam name="T">The underlying type of the meaningful value.</typeparam>
    /// <returns>A sequence of <typeparam name="T"></typeparam> values. </returns>
    public static IEnumerable<T> Somethings<T>(this IEnumerable<Option<T>> options) =>
        options.Where(o => o is Something<T>).Cast<Something<T>>().Select(s => s.Value);
}