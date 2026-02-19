namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSArray pointer.
/// </summary>
public class NSArray(nint nativePtr) : NativeObject(nativePtr)
{
    public nuint Count => ObjectiveCRuntime.MsgSendNUInt(NativePtr, NSArrayBindings.Count);

    public nint ObjectAtIndex(nint index)
    {
        return ObjectiveCRuntime.MsgSendPtr(NativePtr, NSArrayBindings.ObjectAtIndex, index);
    }
}

file static class NSArrayBindings
{
    public static readonly Selector Count = "count";

    public static readonly Selector ObjectAtIndex = "objectAtIndex:";
}