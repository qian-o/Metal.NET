namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSArray pointer.
/// </summary>
public class NSArray : NativeObject
{
    public NSArray(nint nativePtr) : base(nativePtr)
    {
    }

    public nuint Count => ObjectiveCRuntime.MsgSendNUInt(NativePtr, NSArraySelector.Count);

    public nint ObjectAtIndex(nint index)
    {
        return ObjectiveCRuntime.MsgSendPtr(NativePtr, NSArraySelector.ObjectAtIndex, index);
    }
}

file class NSArraySelector
{
    public static readonly Selector Count = Selector.Register("count");

    public static readonly Selector ObjectAtIndex = Selector.Register("objectAtIndex:");
}