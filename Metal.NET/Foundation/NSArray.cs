namespace Metal.NET;

/// <summary>
/// Utility methods for converting between Objective-C NSArray and C# arrays.
/// </summary>
public static class NSArray
{
    /// <summary>
    /// Converts an Objective-C NSArray pointer to a C# array.
    /// The returned elements are borrowed references.
    /// </summary>
    public static T[] ToArray<T>(nint nativePtr) where T : NativeObject, INativeObject<T>
    {
        nuint count = ObjectiveCRuntime.MsgSendNUInt(nativePtr, NSArrayBindings.Count);

        T[] result = new T[(int)count];

        for (nuint i = 0; i < count; i++)
        {
            nint elemPtr = ObjectiveCRuntime.MsgSendPtr(nativePtr, NSArrayBindings.ObjectAtIndex, i);

            result[(int)i] = T.Create(elemPtr, false);
        }

        return result;
    }

    /// <summary>
    /// Creates an Objective-C NSArray from a C# array and returns the native pointer.
    /// The caller owns the returned NSArray.
    /// </summary>
    public static unsafe nint FromArray<T>(T[] array) where T : NativeObject
    {
        nint[] nativePtrs = new nint[array.Length];

        for (int i = 0; i < array.Length; i++)
        {
            nativePtrs[i] = array[i].NativePtr;
        }

        fixed (nint* ptrs = nativePtrs)
        {
            return ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.Alloc(NSArrayBindings.Class), NSArrayBindings.InitWithObjectsCount, (nint)ptrs, (nuint)array.Length);
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