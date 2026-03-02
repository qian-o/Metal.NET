namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSDictionary with access to keys, values, and lookup by key.
/// </summary>
public class NSDictionary(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSDictionary>
{
    public static NSDictionary Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSDictionary Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    /// <summary>
    /// Gets the number of entries in the dictionary.
    /// </summary>
    public nuint Count
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, NSDictionaryBindings.Count);
    }

    /// <summary>
    /// Gets an NSArray of all keys in the dictionary.
    /// </summary>
    public T[] AllKeys<T>() where T : NativeObject, INativeObject<T>
    {
        nint arrayPtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, NSDictionaryBindings.AllKeys);

        return NSArray.ToArray<T>(arrayPtr);
    }

    /// <summary>
    /// Gets an NSArray of all values in the dictionary.
    /// </summary>
    public T[] AllValues<T>() where T : NativeObject, INativeObject<T>
    {
        nint arrayPtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, NSDictionaryBindings.AllValues);

        return NSArray.ToArray<T>(arrayPtr);
    }

    /// <summary>
    /// Returns the value associated with the given key, or null if the key is not found.
    /// </summary>
    /// <param name="key">The key to look up.</param>
    /// <returns>A borrowed wrapper around the value, or null if not found.</returns>
    public T? ObjectForKey<T>(NativeObject key) where T : NativeObject, INativeObject<T>
    {
        nint result = ObjectiveCRuntime.MsgSendPtr(NativePtr, NSDictionaryBindings.ObjectForKey, key.NativePtr);

        return result != 0 ? T.Create(result, NativeObjectOwnership.Borrowed) : null;
    }

    /// <summary>
    /// Creates an NSDictionary from parallel arrays of keys and values.
    /// The caller owns the returned pointer and must call <c>release</c> when done.
    /// </summary>
    public static unsafe NSDictionary FromKeysAndValues<TKey, TValue>(TKey[] keys, TValue[] values)
        where TKey : NativeObject
        where TValue : NativeObject
    {
        if (keys.Length != values.Length)
        {
            throw new ArgumentException("Keys and values arrays must have the same length.");
        }

        nint[] keyPtrs = [.. keys.Select(k => k.NativePtr)];
        nint[] valuePtrs = [.. values.Select(v => v.NativePtr)];

        fixed (nint* pKeys = keyPtrs)
        fixed (nint* pValues = valuePtrs)
        {
            nint nativePtr = ObjectiveCRuntime.MsgSendPtr(
                ObjectiveCRuntime.Alloc(NSDictionaryBindings.Class),
                NSDictionaryBindings.InitWithObjectsForKeysCount,
                (nint)pValues,
                (nint)pKeys,
                (nuint)keys.Length);

            return new(nativePtr, NativeObjectOwnership.Owned);
        }
    }
}

file static class NSDictionaryBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("NSDictionary");

    public static readonly Selector Count = "count";

    public static readonly Selector AllKeys = "allKeys";

    public static readonly Selector AllValues = "allValues";

    public static readonly Selector ObjectForKey = "objectForKey:";

    public static readonly Selector InitWithObjectsForKeysCount = "initWithObjects:forKeys:count:";
}
