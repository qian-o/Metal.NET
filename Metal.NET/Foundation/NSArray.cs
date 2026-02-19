namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSArray pointer.
/// </summary>
public class NSArray(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public nuint Count
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, NSArrayBindings.Count);
    }

    /// <summary>
    /// Returns the object at the given index, or <c>null</c> if the pointer is zero.
    /// The returned object is an unowned view managed by Objective-C.
    /// </summary>
    public T? ObjectAtIndex<T>(nuint index) where T : NativeObject
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, NSArrayBindings.ObjectAtIndex, index);

        if (nativePtr is 0)
        {
            return null;
        }

        return (T)Activator.CreateInstance(typeof(T), nativePtr, false)!;
    }
}

file static class NSArrayBindings
{
    public static readonly Selector Count = "count";

    public static readonly Selector ObjectAtIndex = "objectAtIndex:";
}