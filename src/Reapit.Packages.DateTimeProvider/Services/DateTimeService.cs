namespace Reapit.Packages.DateTimeProvider.Services;

/// <summary>
/// Class defining methods and properties used when interacting with date and time information
/// </summary>
public class DateTimeService : IDateTimeService
{
    /// <inheritdoc/>
    public DateTimeOffset Now => DateTimeOffset.Now;
    
    /// <summary>
    /// Initialize a new instance of the <see cref="DateTimeService"/> class
    /// </summary>
    public DateTimeService()
    {
    }
}