namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSArray pointer.
/// </summary>
public class NSArray(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public nuint Count
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, NSArrayBindings.Count);
    }

    public T? ObjectAtIndex<T>(nuint index) where T : NativeObject
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, NSArrayBindings.ObjectAtIndex, index);

        if (nativePtr is 0)
        {
            return null;
        }

        return (T)Activator.CreateInstance(typeof(T), nativePtr, true)!;
    }
}

file static class NSArrayBindings
{
    public static readonly Selector Count = "count";

    public static readonly Selector ObjectAtIndex = "objectAtIndex:";
}