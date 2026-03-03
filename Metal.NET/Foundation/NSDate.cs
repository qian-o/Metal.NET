namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSDate for date and time representation.
/// </summary>
public class NSDate(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSDate>
{
    public static NSDate Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSDate Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public double TimeIntervalSince1970
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, NSDateBindings.TimeIntervalSince1970);
    }

    public double TimeIntervalSinceNow
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, NSDateBindings.TimeIntervalSinceNow);
    }

    public double TimeIntervalSinceReferenceDate
    {
        get => ObjectiveCRuntime.MsgSendDouble(NativePtr, NSDateBindings.TimeIntervalSinceReferenceDate);
    }

    public NSString Description
    {
        get => GetProperty(ref field, NSDateBindings.Description);
    }

    public static NSDate Date()
    {
        return new(ObjectiveCRuntime.MsgSendPtr(NSDateBindings.Class, NSDateBindings.Date), NativeObjectOwnership.Owned);
    }

    public static NSDate DateWithTimeIntervalSince1970(double secs)
    {
        return new(ObjectiveCRuntime.MsgSendPtr(NSDateBindings.Class, NSDateBindings.DateWithTimeIntervalSince1970, secs), NativeObjectOwnership.Owned);
    }

    public static NSDate DistantPast
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NSDateBindings.Class, NSDateBindings.DistantPast), NativeObjectOwnership.Borrowed);
    }

    public static NSDate DistantFuture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NSDateBindings.Class, NSDateBindings.DistantFuture), NativeObjectOwnership.Borrowed);
    }

    public DateTimeOffset ToDateTimeOffset()
    {
        return DateTimeOffset.FromUnixTimeMilliseconds((long)(TimeIntervalSince1970 * 1000));
    }

    public static implicit operator NSDate(DateTimeOffset dateTime)
    {
        return DateWithTimeIntervalSince1970(dateTime.ToUnixTimeMilliseconds() / 1000.0);
    }

    public override string ToString()
    {
        return Description.Value;
    }
}

file static class NSDateBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("NSDate");

    public static readonly Selector TimeIntervalSince1970 = "timeIntervalSince1970";

    public static readonly Selector TimeIntervalSinceNow = "timeIntervalSinceNow";

    public static readonly Selector TimeIntervalSinceReferenceDate = "timeIntervalSinceReferenceDate";

    public static readonly Selector Description = "description";

    public static readonly Selector Date = "date";

    public static readonly Selector DateWithTimeIntervalSince1970 = "dateWithTimeIntervalSince1970:";

    public static readonly Selector DistantPast = "distantPast";

    public static readonly Selector DistantFuture = "distantFuture";
}
