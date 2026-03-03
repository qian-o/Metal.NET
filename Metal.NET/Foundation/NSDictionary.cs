namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSDictionary for key-value access.
/// </summary>
public class NSDictionary(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSDictionary>
{
    public static NSDictionary Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSDictionary Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public nuint Count
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, NSDictionaryBindings.Count);
    }

    public nint ObjectForKey(nint key)
    {
        return ObjectiveCRuntime.MsgSendPtr(NativePtr, NSDictionaryBindings.ObjectForKey, key);
    }
}

file static class NSDictionaryBindings
{
    public static readonly Selector Count = "count";

    public static readonly Selector ObjectForKey = "objectForKey:";
}
