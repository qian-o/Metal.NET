namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSArray pointer.
/// </summary>
public readonly struct NSArray(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public nuint Count => ObjectiveCRuntime.MsgSendNUInt(NativePtr, NSArrayBindings.Count);

    public nint ObjectAtIndex(nint index)
    {
        return ObjectiveCRuntime.MsgSendPtr(NativePtr, NSArrayBindings.ObjectAtIndex, index);
    }
}

file static class NSArrayBindings
{
    public static readonly Selector Count = Selector.Register("count");

    public static readonly Selector ObjectAtIndex = Selector.Register("objectAtIndex:");
}