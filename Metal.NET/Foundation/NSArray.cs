namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSArray pointer.
/// </summary>
public class NSArray(nint nativePtr) : NativeObject(nativePtr)
{
    public nuint Count => ObjectiveCRuntime.MsgSendNUInt(NativePtr, NSArrayBindings.Count);

    public T? ObjectAtIndex<T>(nuint index) where T : NativeObject
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, NSArrayBindings.ObjectAtIndex, index);

        return nativePtr is not 0 ? (T)Activator.CreateInstance(typeof(T), nativePtr)! : null;
    }
}

file static class NSArrayBindings
{
    public static readonly Selector Count = "count";

    public static readonly Selector ObjectAtIndex = "objectAtIndex:";
}