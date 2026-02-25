namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSArray pointer.
/// </summary>
public class NSArray(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<NSArray>
{
    public static NSArray Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public nuint Count
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, NSArrayBindings.Count);
    }

    /// <summary>
    /// Returns the object at the given index.
    /// The returned pointer is borrowed (not +1 retained) per Objective-C conventions.
    /// </summary>
    public T ObjectAtIndex<T>(nuint index) where T : NativeObject, INativeObject<T>
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, NSArrayBindings.ObjectAtIndex, index);

        return T.Create(nativePtr, false);
    }
}

file static class NSArrayBindings
{
    public static readonly Selector Count = "count";

    public static readonly Selector ObjectAtIndex = "objectAtIndex:";
}