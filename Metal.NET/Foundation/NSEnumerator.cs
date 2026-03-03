namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSEnumerator for collection iteration.
/// </summary>
public class NSEnumerator(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSEnumerator>
{
    public static NSEnumerator Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSEnumerator Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public nint NextObject()
    {
        return ObjectiveCRuntime.MsgSendPtr(NativePtr, NSEnumeratorBindings.NextObject);
    }

    public nint AllObjects
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSEnumeratorBindings.AllObjects);
    }

    public T[] ToArray<T>() where T : NativeObject, INativeObject<T>
    {
        return NSArray.ToArray<T>(AllObjects);
    }
}

file static class NSEnumeratorBindings
{
    public static readonly Selector NextObject = "nextObject";

    public static readonly Selector AllObjects = "allObjects";
}
