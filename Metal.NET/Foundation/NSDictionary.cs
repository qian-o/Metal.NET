namespace Metal.NET;

/// <summary>A static collection of objects associated with unique keys.</summary>
public class NSDictionary(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<NSDictionary>
{
    #region INativeObject
    public static new NSDictionary Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new NSDictionary New(nint nativePtr, NativeObjectOwnership ownership)
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
        return ObjectiveC.MsgSendNInt(NativePtr, NSDictionaryBindings.ObjectForKey, key);
    }
}

file static class NSDictionaryBindings
{
    public static readonly Selector Count = "count";

    public static readonly Selector ObjectForKey = "objectForKey:";
}
