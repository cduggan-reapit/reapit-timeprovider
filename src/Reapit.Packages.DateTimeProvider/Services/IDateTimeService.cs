namespace Reapit.Packages.DateTimeProvider.Services;

/// <summary>
/// Interface describing methods and properties used when interacting with date and time information
/// </summary>
public interface IDateTimeService
{
    /// <summary>
    /// Gets a <see cref="DateTimeOffset"/> object that is set to the current date and time on the current computer,
    /// with the offset set to the local time's offset from Coordinated Universal Time (UTC).
    /// </summary>
    /// <returns>
    /// A <see cref="DateTimeOffset"/> object whose date and time is the current local time and whose offset is the
    /// local time zone's offset from Coordinated Universal Time (UTC).
    /// </returns>
    DateTimeOffset Now { get; }
}