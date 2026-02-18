namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSArray pointer.
/// </summary>
public class NSArray(nint nativePtr) : NativeObject(nativePtr)
{
    public nuint Count => ObjectiveCRuntime.MsgSendNUInt(NativePtr, NSArraySelector.Count);

    public nint ObjectAtIndex(nint index)
    {
        return ObjectiveCRuntime.MsgSendPtr(NativePtr, NSArraySelector.ObjectAtIndex, index);
    }
}

file static class NSArraySelector
{
    public static readonly Selector Count = Selector.Register("count");

    public static readonly Selector ObjectAtIndex = Selector.Register("objectAtIndex:");
}