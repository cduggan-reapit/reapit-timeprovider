namespace Reapit.Packages.DateTimeProvider.Static;

/// <summary>
/// Static <see cref="DateTimeOffset"/> accessor allowing values to be fixed for testing purposes
/// </summary>
public static class SystemDateTime
{
    private static readonly ThreadLocal<Func<DateTimeOffset>> SystemTimeFunction = new(() => () => DateTimeOffset.Now);

    /// <inheritdoc cref="DateTimeOffset.Now"/>
    public static DateTimeOffset Now 
        => SystemTimeFunction.Value!();

    /// <summary>
    /// Sets a fixed time for the current thread to return through <see cref="SystemDateTime"/>
    /// </summary>
    /// <param name="fixedDateTimeOffset">
    /// The <see cref="DateTimeOffset"/> value that <see cref="SystemDateTime.Now"/> should return
    /// </param>
    public static void Set(DateTimeOffset fixedDateTimeOffset)
        => SystemTimeFunction.Value = () => fixedDateTimeOffset;
    
    /// <summary>
    /// Resets the <see cref="SystemDateTime"/> class to return the current <see cref="DateTimeOffset.Now"/> 
    /// </summary>
    public static void Reset()
        => SystemTimeFunction.Value = () => DateTimeOffset.Now;
}