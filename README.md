# Reapit.Packages.DateTimeProvider

If your application includes logic that depends on the current date or time, test results will be different when tests 
are run at different times.  This package intends to provide common methods which make it easier for consumers to write 
highly testable code.

> Note: .NET 8 contains an in-built DateTimeOffset provider that can be used instead of this package, see 
> [TimeProvider](https://learn.microsoft.com/en-us/dotnet/api/system.timeprovider) and 
> [FakeTimeProvider](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.time.testing.faketimeprovider)
> for more information

## Usage

### IDateTimeService

The `IDateTimeService` service allows a date and time provider to be injected into any controllers or services that 
require access to the current date and/or time.

1. Register the date time provider service in the application startup using
    ```csharp
    using Reapit.Packages.DateTimeProvider;
    
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddDateTimeService();
    ```
2. Inject `IDateTimeService` into services requiring access to the current date and/or time
    ```csharp
    private readonly IDateTimeService _dateTimeService; 
   
    public ExampleService(IDateTimeService dateTimeService)
    {
        _dateTimeService = dateTimeService;
    }
    ```
   
3. Use the `IDateTimeService.Now` property to access the current date and time as a `DateTimeOffset`
    ```csharp
    public DateTimeOffset GetNow()
        => _dateTimeService.Now;
    ```
   
#### Testing IDateTimeService

Injecting the `IDateTimeService` allows the service to mocked using a library such as NSubstitute to ensure that a 
consistent date and time is provided.

```csharp
var mockTimestamp = new DateTimeOffset(2016, 4, 16, 9, 53, 17, TimeSpan.FromHours(-5));
var dateTimeMock = Substitute.For<IDateTimeService>();
dateTimeMock.Now.Returns(mockTimestamp);
```

### SystemDateTime

The thread-safe `SystemDateTime` class provides the current date and time as a `DateTimeOffset`, while allowing tests to
override the returned value using it's `Set` method.

1. Use the `SystemDateTime.Now` property to access the current date and time as a `DateTimeOffset`
    ```csharp
    public DateTimeOffset GetNow()
        => SystemDateTime.Now;
    ```
   
#### Testing SystemDateTime

Using the `Set` method fixes the value returned by `SystemDateTime.Now` allowing tests against a known value

```csharp
var fixedDate = new DateTimeOffset(2013, 1, 7, 10, 15, 0, TimeSpan.Zero);
SystemDateTime.Set(fixedDate);
```

## Useful resources:
- [Testing Against Non-Determinism (MSDN Blog)](https://learn.microsoft.com/en-gb/archive/blogs/ploeh/testing-against-non-determinism)
- [Dealing with Time in Tests (Oren Eini)](https://ayende.com/blog/3408/dealing-with-time-in-tests)