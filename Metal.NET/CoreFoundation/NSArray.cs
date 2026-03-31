namespace Metal.NET;

/// <summary>
/// A typed ordered collection of objects backed by an Objective-C NSArray.
/// </summary>
public class NSArray<T>(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<NSArray<T>> where T : NativeObject, INativeObject<T>
{
    #region INativeObject
    public static new NSArray<T> Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new NSArray<T> New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    private T[]? cachedItems;

    public nuint Count
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, NSArrayBindings.Count);
    }

    public T this[nuint index]
    {
        get
        {
            int count = (int)Count;

            if (cachedItems is null || cachedItems.Length != count)
            {
                cachedItems = new T[count];
            }

            nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, NSArrayBindings.ObjectAtIndex, index);

            if (cachedItems[index] is null || cachedItems[index].NativePtr != nativePtr)
            {
                cachedItems[index] = T.New(nativePtr, NativeObjectOwnership.Borrowed);
            }

            return cachedItems[index];
        }
    }

    public static unsafe implicit operator NSArray<T>(T[] array)
    {
        nint[] nativePtrs = [.. array.Select(static item => item.NativePtr)];

        fixed (nint* pNativePtrs = nativePtrs)
        {
            nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSArrayBindings.Class), NSArrayBindings.InitWithObjectsCount, (nint)pNativePtrs, (nuint)array.Length);

            return new(nativePtr, NativeObjectOwnership.Managed);
        }
    }

    public static implicit operator T[](NSArray<T> array)
    {
        int count = (int)array.Count;

        T[] result = new T[count];

        for (int i = 0; i < count; i++)
        {
            result[i] = array[(uint)i];
        }

        return result;
    }
}

file static class NSArrayBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("NSArray");

    public static readonly Selector Count = "count";

    public static readonly Selector ObjectAtIndex = "objectAtIndex:";

    public static readonly Selector InitWithObjectsCount = "initWithObjects:count:";
}