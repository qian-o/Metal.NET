namespace Metal.NET;

/// <summary>
/// Utility methods for converting between Objective-C NSArray and C# arrays.
/// </summary>
public static class NSArray
{
    /// <summary>
    /// Reads each element from an Objective-C NSArray via <c>objectAtIndex:</c>
    /// and wraps them as borrowed references (the array retains the elements).
    /// </summary>
    public static T[] ToArray<T>(nint nativePtr) where T : NativeObject, INativeObject<T>
    {
        nuint count = ObjectiveCRuntime.MsgSendNUInt(nativePtr, NSArrayBindings.Count);

        T[] result = new T[(int)count];

        for (nuint i = 0; i < count; i++)
        {
            result[(int)i] = T.Create(ObjectiveCRuntime.MsgSendPtr(nativePtr, NSArrayBindings.ObjectAtIndex, i), NativeObjectOwnership.Borrowed);
        }

        return result;
    }

    /// <summary>
    /// Creates an Objective-C NSArray from a C# array via <c>initWithObjects:count:</c>.
    /// The caller owns the returned pointer and must call <c>release</c> when done.
    /// </summary>
    public static unsafe nint FromArray<T>(T[] array) where T : NativeObject
    {
        nint[] nativePtrs = [.. array.Select(x => x.NativePtr)];

        fixed (nint* pNativePtrs = nativePtrs)
        {
            return ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.Alloc(NSArrayBindings.Class), NSArrayBindings.InitWithObjectsCount, (nint)pNativePtrs, (nuint)array.Length);
        }
    }
}

file static class NSArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("NSArray");

    public static readonly Selector Count = "count";

    public static readonly Selector ObjectAtIndex = "objectAtIndex:";

    public static readonly Selector InitWithObjectsCount = "initWithObjects:count:";
}