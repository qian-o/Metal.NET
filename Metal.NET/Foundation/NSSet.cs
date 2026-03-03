namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSSet for unordered collection access.
/// </summary>
public class NSSet(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSSet>
{
    public static NSSet Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSSet Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public nuint Count
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, NSSetBindings.Count);
    }

    public nint AnyObject
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSSetBindings.AnyObject);
    }

    public nint AllObjects
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSSetBindings.AllObjects);
    }

    public T[] ToArray<T>() where T : NativeObject, INativeObject<T>
    {
        return NSArray.ToArray<T>(AllObjects);
    }

    public bool ContainsObject(nint obj)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, NSSetBindings.ContainsObject, obj);
    }

    public bool Member(nint obj)
    {
        return ObjectiveCRuntime.MsgSendPtr(NativePtr, NSSetBindings.Member, obj) != 0;
    }

    public NSEnumerator ObjectEnumerator()
    {
        return NSEnumerator.Create(ObjectiveCRuntime.MsgSendPtr(NativePtr, NSSetBindings.ObjectEnumerator), NativeObjectOwnership.Borrowed);
    }
}

file static class NSSetBindings
{
    public static readonly Selector Count = "count";

    public static readonly Selector AnyObject = "anyObject";

    public static readonly Selector AllObjects = "allObjects";

    public static readonly Selector ContainsObject = "containsObject:";

    public static readonly Selector Member = "member:";

    public static readonly Selector ObjectEnumerator = "objectEnumerator";
}
