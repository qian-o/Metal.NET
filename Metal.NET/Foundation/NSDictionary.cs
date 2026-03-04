namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSDictionary for key-value access.
/// </summary>
public class NSDictionary(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<NSDictionary>
{
    #region INativeObject
    public static NSDictionary Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSDictionary New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public nuint Count
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, NSDictionaryBindings.Count);
    }

    public nint ObjectForKey(nint key)
    {
        return ObjectiveC.MsgSendPtr(NativePtr, NSDictionaryBindings.ObjectForKey, key);
    }
}

file static class NSDictionaryBindings
{
    public static readonly Selector Count = "count";

    public static readonly Selector ObjectForKey = "objectForKey:";
}
