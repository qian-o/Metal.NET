namespace Metal.NET;

public static class NSArray
{
    public static T[] ToArray<T>(nint nativePtr) where T : NativeObject, INativeObject<T>
    {
        nuint count = ObjectiveC.MsgSendNUInt(nativePtr, NSArrayBindings.Count);

        T[] result = new T[(int)count];

        for (nuint i = 0; i < count; i++)
        {
            result[(int)i] = T.New(ObjectiveC.MsgSendPtr(nativePtr, NSArrayBindings.ObjectAtIndex, i), NativeObjectOwnership.Borrowed);
        }

        return result;
    }

    public static unsafe nint FromArray<T>(T[] array) where T : NativeObject
    {
        nint[] nativePtrs = [.. array.Select(static item => item.NativePtr)];

        fixed (nint* pNativePtrs = nativePtrs)
        {
            return ObjectiveC.MsgSendPtr(ObjectiveC.Alloc(NSArrayBindings.Class), NSArrayBindings.InitWithObjectsCount, (nint)pNativePtrs, (nuint)array.Length);
        }
    }
}

file static class NSArrayBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("NSArray");

    public static readonly Selector Count = "count";

    public static readonly Selector ObjectAtIndex = "objectAtIndex:";

    public static readonly Selector InitWithObjectsCount = "initWithObjects:count:";
}