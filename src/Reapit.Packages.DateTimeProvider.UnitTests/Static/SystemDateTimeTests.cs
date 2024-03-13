using FluentAssertions;
using Reapit.Packages.DateTimeProvider.Static;

namespace Reapit.Packages.DateTimeProvider.UnitTests.Static;

public class SystemDateTimeTests
{
    // Initialize
    
    [Fact]
    public void Reset_InitializesWithTheCurrentTime()
    {
        SystemDateTime.Now.Should().BeCloseTo(DateTimeOffset.Now, TimeSpan.FromMilliseconds(1));
    }
    
    // Set

    [Fact]
    public void Set_FixesTheSystemTime()
    {
        var timestamp = new DateTimeOffset(2013, 1, 7, 10, 15, 0, TimeSpan.Zero);
        SystemDateTime.Set(timestamp);
        SystemDateTime.Now.Should().Be(timestamp);
    }
    
    // Reset
    
    [Fact]
    public void Reset_ClearsTheFixedSystemTime()
    {
        var timestamp = new DateTimeOffset(2013, 1, 7, 10, 15, 0, TimeSpan.Zero);
        SystemDateTime.Set(timestamp);
        SystemDateTime.Reset();
        SystemDateTime.Now.Should().BeCloseTo(DateTimeOffset.Now, TimeSpan.FromMilliseconds(1));
    }
}